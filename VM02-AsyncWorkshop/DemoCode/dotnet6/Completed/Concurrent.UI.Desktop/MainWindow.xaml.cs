using System.Windows;
using TaskAwait.Library;
using TaskAwait.Shared;

namespace Concurrent.UI;

public partial class MainWindow : Window
{
    PersonReader reader = new();
    CancellationTokenSource? tokenSource;

    public MainWindow()
    {
        InitializeComponent();
    }

    // Using Task (Single Continuation)
    private void FetchWithTaskButton_Click(object sender, RoutedEventArgs e)
    {
        tokenSource = new();
        FetchWithTaskButton.IsEnabled = false;
        ClearListBox();

        Task<List<Person>> peopleTask = reader.GetPeopleAsync(tokenSource.Token);

        // Always
        peopleTask.ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    foreach (var ex in task.Exception!.Flatten().InnerExceptions)
                        MessageBox.Show($"ERROR\n{ex.GetType()}\n{ex.Message}");
                }
                if (task.IsCanceled)
                {
                    MessageBox.Show("CANCELED CANCELED CANCELED");
                }

                if (task.IsCompletedSuccessfully)
                {
                    List<Person> people = task.Result;
                    foreach (var person in people)
                    {
                        PersonListBox.Items.Add(person);
                    }
                }

                FetchWithTaskButton.IsEnabled = true;
                tokenSource.Dispose();
            },
            tokenSource.Token,
            TaskContinuationOptions.None,
            TaskScheduler.FromCurrentSynchronizationContext());
    }

    //// Using Task (Multiple Continuations)
    //private void FetchWithTaskButton_Click(object sender, RoutedEventArgs e)
    //{
    //    FetchWithTaskButton.IsEnabled = false;
    //    ClearListBox();

    //    Task<List<Person>> peopleTask = reader.GetPeopleAsync();

    //    // Success
    //    peopleTask.ContinueWith(task =>
    //        {
    //            List<Person> people = task.Result;
    //            foreach (var person in people)
    //            {
    //                PersonListBox.Items.Add(person);
    //            }
    //        },
    //        CancellationToken.None,
    //        TaskContinuationOptions.OnlyOnRanToCompletion,
    //        TaskScheduler.FromCurrentSynchronizationContext());

    //    // Faulted (Exception)
    //    peopleTask.ContinueWith(task =>
    //        {
    //            foreach (var ex in task.Exception!.Flatten().InnerExceptions)
    //                MessageBox.Show($"ERROR\n{ex.GetType()}\n{ex.Message}");
    //        },
    //        CancellationToken.None,
    //        TaskContinuationOptions.OnlyOnFaulted,
    //        TaskScheduler.FromCurrentSynchronizationContext());

    //    // Always
    //    peopleTask.ContinueWith(task =>
    //        {
    //            FetchWithTaskButton.IsEnabled = true;
    //        },
    //        TaskScheduler.FromCurrentSynchronizationContext());
    //}

    // Using Await
    private async void FetchWithAwaitButton_Click(object sender, RoutedEventArgs e)
    {
        using (tokenSource = new())
        {
            FetchWithAwaitButton.IsEnabled = false;
            ClearListBox();

            try
            {
                List<Person> people = await reader.GetPeopleAsync(tokenSource.Token);
                foreach (var person in people)
                {
                    PersonListBox.Items.Add(person);
                }
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show($"CANCELED CANCELED CANCELED\n{ex.GetType()}\n{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR\n{ex.GetType()}\n{ex.Message}");
            }
            finally
            {
                FetchWithAwaitButton.IsEnabled = true;
            }
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            tokenSource?.Cancel();
        }
        catch (Exception)
        {
            // if there's something wrong with the
            // cancellation token source, just ignore it
            // (it may be disposed because nothing is running)
        }
    }

    private void ClearListBox()
    {
        PersonListBox.Items.Clear();
    }
}
