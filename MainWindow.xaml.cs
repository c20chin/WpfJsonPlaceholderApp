using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfJsonPlaceholderApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Post> posts;
        private bool showUserIds = false;

        public MainWindow()
        {
            InitializeComponent();
            FetchPosts();
        }

        private async void FetchPosts()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://jsonplaceholder.typicode.com/posts";
                    var response = await client.GetStringAsync(url);
                    posts = JsonConvert.DeserializeObject<List<Post>>(response).Take(100).ToList();
                    DisplayPosts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to fetch posts: " + ex.Message);
            }
        }

        private void DisplayPosts()
        {
            if (posts == null || posts.Count == 0)
            {
                MessageBox.Show("No posts to display.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            PostsGrid.Children.Clear();

            double buttonSize = Math.Min((ActualWidth -38) / 11, (ActualHeight-38) / 11);  // Calculate button size based on window size

            buttonSize = Math.Max(buttonSize, 50);

            foreach (var post in posts)
            {
                Button btn = new Button
                {
                    Content = post.Id,
                    Width = buttonSize,
                    Height = buttonSize,
                    Margin = new Thickness(2),
                    FontSize = 16,
                    Background = Brushes.SlateGray,
                    Foreground = Brushes.White,
                    ToolTip = $"Post ID: {post.Id}",
                };
                btn.Click += PostButton_Click;

                PostsGrid.Children.Add(btn);
            }
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the boolean flag
            showUserIds = !showUserIds;

            // Update the title text based on the toggle state
            TitleTextBlock.Text = showUserIds ? "You are looking at UserId" : "You are looking at Id";

            // Update the content of each button based on the toggle state
            foreach (Button btn in PostsGrid.Children)
            {
                // Use the current index to find the corresponding post
                int index = PostsGrid.Children.IndexOf(btn);
                var post = posts[index];

                // Update the content to either show the Id or UserId
                btn.Content = showUserIds ? post.UserId : post.Id;
            }
        }
    }

    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}