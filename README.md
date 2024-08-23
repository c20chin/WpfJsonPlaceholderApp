# WPF JSONPlaceholder App

## Overview

This WPF (Windows Presentation Foundation) application fetches and displays 100 posts from the [JSONPlaceholder API](https://jsonplaceholder.typicode.com/). The application presents each post in a square button arranged in a 10x10 grid. Users can toggle between viewing post IDs and user IDs by clicking on any button.

## Features

- Displays 100 posts in a 10x10 grid.
- Each button initially shows the post ID.
- Clicking a button toggles the display between post IDs and user IDs.
- Responsive layout that adjusts button size based on window size.
- Smooth animations for button color changes on hover and click.

## App Demo
https://github.com/user-attachments/assets/1777bba5-bbec-4acd-8b8f-45ee461cbf53


## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (includes .NET Core Runtime).
- [Visual Studio](https://visualstudio.microsoft.com/) or another IDE that supports .NET Core and WPF development.
- **Packages**:
  - `Newtonsoft.Json` for JSON parsing.
  
### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/c20chin/WpfJsonPlaceholderApp.git
   ```

2. **Open the Project**:
    - Launch Visual Studio.
    - Go to `File` > `Open` > `Project/Solution`.
    - Navigate to the cloned repository directory and select the `.sln` file.

3. **Build and Run**:
    - In Visual Studio, go to `Build` > `Build Solution` (or press `Ctrl+Shift+B`).
    - To run the application, press `F5` or go to `Debug` > `Start Debugging`.

### Usage

1. **Viewing Posts**:
    - The application will [display 100 posts](https://jsonplaceholder.typicode.com/posts) in a 10x10 grid.
    - Each button represents a post and initially displays the post ID.

2. **Toggling Between ID and User ID**:
    - Click on any button to switch the display to the user ID for all buttons.
    - Click again to switch back to displaying post IDs.

### UI/UX

- **Title**: Displays "You are looking at Id" or "You are looking at UserId" based on the current display mode.
- **Styling**: Buttons have hover and click animations for a polished user experience.

## Code Structure

- **`MainWindow.xaml`**: Contains the XAML code for defining the user interface.
- **`MainWindow.xaml.cs`**: Contains the code-behind for handling the logic of fetching posts, handling button clicks, and updating the UI.

## Acknowledgments

- **JSONPlaceholder API**: A free online REST API for testing and prototyping.
- **Microsoft**: For providing the .NET Framework and Visual Studio for development.
