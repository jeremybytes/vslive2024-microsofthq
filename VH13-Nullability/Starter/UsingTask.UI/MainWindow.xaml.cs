﻿using System.Windows;
using UsingTask.Library;
using UsingTask.Shared;

namespace UsingTask.UI;

public partial class MainWindow : Window
{
    private IPersonReader reader;
    public IPersonReader Reader
    {
        get => reader;
        set => reader = value;
    }

    CancellationTokenSource tokenSource;

    public MainWindow()
    {
        InitializeComponent();
        reader = new PersonReader();
    }

    private void FetchWithTaskButton_Click(object sender, RoutedEventArgs e)
    {
        tokenSource = new CancellationTokenSource();
        FetchWithTaskButton.IsEnabled = false;
        ClearListBox();

        Task<List<Person>> peopleTask = Reader.GetAsync(tokenSource.Token);

        // Success
        peopleTask.ContinueWith(task =>
        {
            List<Person> people = task.Result;
            foreach (var person in people)
                PersonListBox.Items.Add(person);
        },
        CancellationToken.None,
        TaskContinuationOptions.OnlyOnRanToCompletion,
        TaskScheduler.FromCurrentSynchronizationContext());

        // Faulted
        peopleTask.ContinueWith(task =>
        {
            foreach (var ex in task.Exception.Flatten().InnerExceptions)
                Log(ex);
        },
        CancellationToken.None,
        TaskContinuationOptions.OnlyOnFaulted,
        TaskScheduler.FromCurrentSynchronizationContext());

        // Canceled
        peopleTask.ContinueWith(task => MessageBox.Show("CANCELED"),
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());

        // Always
        peopleTask.ContinueWith(task => FetchWithTaskButton.IsEnabled = true,
            TaskScheduler.FromCurrentSynchronizationContext());
    }

    private async void FetchWithAwaitButton_Click(object sender, RoutedEventArgs e)
    {
        tokenSource = new CancellationTokenSource();
        FetchWithAwaitButton.IsEnabled = false;
        try
        {
            ClearListBox();

            List<Person> people = await Reader.GetAsync(tokenSource.Token);
            foreach (var person in people)
                PersonListBox.Items.Add(person);
        }
        catch (OperationCanceledException ex)
        {
            MessageBox.Show($"CANCELED\n{ex.GetType()}\n{ex.Message}");
        }
        catch (Exception ex)
        {
            Log(ex);
        }
        finally
        {
            FetchWithAwaitButton.IsEnabled = true;
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        tokenSource.Cancel();
    }

    private void ClearListBox()
    {
        PersonListBox.Items.Clear();
    }

    private static void Log(Exception ex)
    {
        // NOTE: This is for example purposes only
        // It is generally a bad idea to show a raw exception
        // message in the application. But it is available
        // for your normal logging system.
        MessageBox.Show($"ERROR\n{ex.GetType()}\n{ex.Message}");
    }
}
