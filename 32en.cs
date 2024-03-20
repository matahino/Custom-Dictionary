using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TableLayoutPanel tableLayoutPanel;
    private PictureBox pictureBox;
    private Button searchButton;
    private RichTextBox richTextBox;
    private Panel mainPanel;
    private Panel settingsPanel;
    private Panel addDictionaryPanel;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem outputToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;

    public Form1()
    {
        InitializeComponent();
        InitializeMenu();
    }

    private void InitializeComponent()
    {
        // Form Setup
        this.Text = "Dictionary";
        this.ClientSize = new Size(800, 500); // Adjust width

        // Main Panel configuration
        mainPanel = new Panel
        {
            Dock = DockStyle.Fill
        };
        Controls.Add(mainPanel);

        // TableLayoutPanel configuration
        tableLayoutPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 13,
            ColumnCount = 11, // number of columns
            Padding = new Padding(0)
        };
        mainPanel.Controls.Add(tableLayoutPanel);

        // Set row height
        for (int i = 0; i < tableLayoutPanel.RowCount; i++)
        {
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / tableLayoutPanel.RowCount));
        }

        // Set column width
        for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
        {
            // Fix the width of the first column
            if (i == 0)
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100)); // Set fixed width
            else
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / (tableLayoutPanel.ColumnCount - 1))); // Set percentage width
        }

        // Add an image to the first row
        pictureBox = new PictureBox
        {
            Image = Image.FromFile("04.jpg"), // Specify the path to the image
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            SizeMode = PictureBoxSizeMode.StretchImage // Stretch and display the image
        };

        tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
        tableLayoutPanel.SetColumnSpan(pictureBox, 11); // Set column span

        // Fill rows 11 and after with dark blue
        for (int row = 10; row < tableLayoutPanel.RowCount; row++)
        {
            for (int col = 0; col < tableLayoutPanel.ColumnCount; col++)
            {
                var panel = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.DarkBlue,
                    Margin = new Padding(0) // Remove spaces between columns
                };
                tableLayoutPanel.Controls.Add(panel, col, row);
            }
        }

        // Fill columns 12 and after with dark blue
        for (int row = 0; row < tableLayoutPanel.RowCount; row++)
        {
            for (int col = 11; col < tableLayoutPanel.ColumnCount; col++)
            {
                var panel = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.DarkBlue,
                    Margin = new Padding(0) // Remove spaces between columns
                };
                tableLayoutPanel.Controls.Add(panel, col, row);
            }
        }

        // Add a Label that displays "Custom Dictionary" in large letters in row 6, columns 3 to 9 and row 7, columns 3 to 9
        var customDictionaryLabel = new Label
        {
            Text = "Custom Dictionary",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe Script", 25, FontStyle.Bold),
            ForeColor = Color.Black,
            AutoSize = false
        };
        tableLayoutPanel.Controls.Add(customDictionaryLabel, 2, 5);
        tableLayoutPanel.SetColumnSpan(customDictionaryLabel, 7);
        tableLayoutPanel.SetRowSpan(customDictionaryLabel, 2);

        // Row 3, column 8 and row 3, column 9 for Search Button
        searchButton = new Button
        {
            Text = "Search",
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            BackColor = Color.Black,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat, // Make the button a rectangle
            FlatAppearance = { BorderSize = 1, BorderColor = Color.Black } // Add black lines around the button
        };
        tableLayoutPanel.Controls.Add(searchButton, 7, 2);
        tableLayoutPanel.SetColumnSpan(searchButton, 2); // Set column span to 2

        // Add rich text box
        richTextBox = new RichTextBox
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            BorderStyle = BorderStyle.FixedSingle,
            Font = new Font("MS UI Gothic", 18, FontStyle.Regular),
            Multiline = false // Disable multiple lines
        };
        tableLayoutPanel.Controls.Add(richTextBox, 2, 2);
        tableLayoutPanel.SetColumnSpan(richTextBox, 5);

        // Settings Panel
        settingsPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Visible = false
        };
        Controls.Add(settingsPanel);

        var settingsLabel = new Label
        {
            Text = "Settings Page",
            AutoSize = true,
            Location = new Point(10, 10)
        };
        settingsPanel.Controls.Add(settingsLabel);

        var backButton = new Button
        {
            Text = "Back",
            Location = new Point(10, 40),
            AutoSize = true
        };
        backButton.Click += BackButton_Click;
        settingsPanel.Controls.Add(backButton);

        // Add Dictionary Panel
        addDictionaryPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Visible = false
        };
        Controls.Add(addDictionaryPanel);

        // Add controls for the Add Dictionary page
        var addDictionaryLabel = new Label
        {
            Text = "Add Dictionary Page",
            AutoSize = true,
            Location = new Point(10, 10)
        };
        addDictionaryPanel.Controls.Add(addDictionaryLabel);

        var backButton2 = new Button
        {
            Text = "Back",
            Location = new Point(10, 40),
            AutoSize = true
        };
        backButton2.Click += BackButton2_Click;
        addDictionaryPanel.Controls.Add(backButton2);
    }

    private void InitializeMenu()
    {
        // Create menu
        var menuStrip = new MenuStrip();
        menuStrip.BackColor = Color.White; // Set menu bar color to white

        // Create "File" menu
        var fileToolStripMenuItem = new ToolStripMenuItem("File");

        openToolStripMenuItem = new ToolStripMenuItem("Open");
        openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
        fileToolStripMenuItem.DropDownItems.Add(openToolStripMenuItem);

        outputToolStripMenuItem = new ToolStripMenuItem("Output");
        outputToolStripMenuItem.Click += OutputToolStripMenuItem_Click;
        fileToolStripMenuItem.DropDownItems.Add(outputToolStripMenuItem);

        exitToolStripMenuItem = new ToolStripMenuItem("Exit");
        exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
        fileToolStripMenuItem.DropDownItems.Add(exitToolStripMenuItem);

        menuStrip.Items.Add(fileToolStripMenuItem);

        // Create "Settings" menu
        var editToolStripMenuItem = new ToolStripMenuItem("Settings");
        var appSettingsToolStripMenuItem = new ToolStripMenuItem("App Settings");
        appSettingsToolStripMenuItem.Click += AppSettingsToolStripMenuItem_Click;
        editToolStripMenuItem.DropDownItems.Add(appSettingsToolStripMenuItem);
        var addDictionaryToolStripMenuItem = new ToolStripMenuItem("Add Dictionary");
        addDictionaryToolStripMenuItem.Click += AddDictionaryToolStripMenuItem_Click;
        editToolStripMenuItem.DropDownItems.Add(addDictionaryToolStripMenuItem);
        menuStrip.Items.Add(editToolStripMenuItem);

        // Create "Help" menu
        var helpToolStripMenuItem = new ToolStripMenuItem("Help");
        helpToolStripMenuItem.DropDownItems.Add("Version Information");
        menuStrip.Items.Add(helpToolStripMenuItem);

        // Add menu to the form
        this.MainMenuStrip = menuStrip;
        this.Controls.Add(menuStrip);
    }

    private void AppSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        mainPanel.Visible = false;
        settingsPanel.Visible = true;
        addDictionaryPanel.Visible = false;
    }

    private void AddDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        mainPanel.Visible = false;
        settingsPanel.Visible = false;
        addDictionaryPanel.Visible = true;
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        settingsPanel.Visible = false;
        mainPanel.Visible = true;
    }

    private void BackButton2_Click(object sender, EventArgs e)
    {
        addDictionaryPanel.Visible = false;
        mainPanel.Visible = true;
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Add code for handling the "Open" menu item click event
        // For example, display a dialog to open a file
        MessageBox.Show("\"Open\" menu item clicked.");
    }

    private void OutputToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Add code for handling the "Output" menu item click event
        // For example, display a dialog to save a file
        MessageBox.Show("\"Output\" menu item clicked.");
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Add code for handling the "Exit" menu item click event
        // For example, exit the application
        Application.Exit();
    }
}

public class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}