using System.Windows;
using UsingTask.Library;
using UsingTask.Shared;

namespace UsingTask.UI;

public partial class MainWindow : Window
{
    IPersonReader? reader;
    public IPersonReader Reader
    {
        //get
        //{
        //    if (reader is null)
        //        reader = new PersonReader();
        //    return reader;
        //}

        //get
        //{
        //    reader = reader ?? new PersonReader();
        //    return reader;
        //}

        //get
        //{
        //    reader ??= new PersonReader();
        //    return reader;
        //}

        //get { return reader ??= new PersonReader(); }

        get => reader ??= new PersonReader();
        set => reader = value;
    }

    CancellationTokenSource? tokenSource;

    public MainWindow() => InitializeComponent();

    void FetchWithTaskButton_Click(object sender, RoutedEventArgs e)
    {
        tokenSource = new CancellationTokenSource();
        FetchWithTaskButton.IsEnabled = false;
        ClearListBox();

        Task<List<Person>> peopleTask = Reader.GetAsync(tokenSource.Token);

        // Success
        _ = peopleTask.ContinueWith(task =>
        {
            List<Person> people = task.Result;
            foreach (Person person in people)
            {
                _ = PersonListBox.Items.Add(person);
            }
        },
        CancellationToken.None,
        TaskContinuationOptions.OnlyOnRanToCompletion,
        TaskScheduler.FromCurrentSynchronizationContext());

        // Faulted
        _ = peopleTask.ContinueWith(task =>
        {
            foreach (Exception ex in task.Exception!.Flatten().InnerExceptions)
            {
                Log(ex);
            }
        },
        CancellationToken.None,
        TaskContinuationOptions.OnlyOnFaulted,
        TaskScheduler.FromCurrentSynchronizationContext());

        // Canceled
        _ = peopleTask.ContinueWith(task => MessageBox.Show("CANCELED"),
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());

        // Always
        _ = peopleTask.ContinueWith(task => FetchWithTaskButton.IsEnabled = true,
            TaskScheduler.FromCurrentSynchronizationContext());
    }

    async void FetchWithAwaitButton_Click(object sender, RoutedEventArgs e)
    {
        tokenSource = new CancellationTokenSource();
        FetchWithAwaitButton.IsEnabled = false;
        try
        {
            ClearListBox();

            List<Person> people = await Reader.GetAsync(tokenSource.Token);
            foreach (Person person in people)
            {
                _ = PersonListBox.Items.Add(person);
            }
        }
        catch (OperationCanceledException ex)
        {
            _ = MessageBox.Show($"CANCELED\n{ex.GetType()}\n{ex.Message}");
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

    void CancelButton_Click(object sender, RoutedEventArgs e) =>
        //if (tokenSource is not null)
        //    tokenSource.Cancel();

        tokenSource?.Cancel();

    void ClearListBox() => PersonListBox.Items.Clear();

    static void Log(Exception ex) =>
        // NOTE: This is for example purposes only
        // It is generally a bad idea to show a raw exception
        // message in the application. But it is available
        // for your normal logging system.
        MessageBox.Show($"ERROR\n{ex.GetType()}\n{ex.Message}");
}
