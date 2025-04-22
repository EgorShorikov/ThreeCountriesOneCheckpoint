using ThreeCountriesOneCheckpoint.Controler;
using ThreeCountriesOneCheckpoint.Models;

namespace ThreeCountriesOneCheckpoint.Views
{
    public class MainForm : Form
    {
        private Label lblName;
        private Label lblCountry;
        private Label lblDialogue;
        private Button btnAllow;
        private Button btnDeny;
        private PictureBox boxShowImage;
        private TableLayoutPanel mainTable;
        private PictureBox boxCurrencyBook;
        private Button btnCurrencyBook;

        private GameController _controller;

        public MainForm()
        {
            this.Text = "ThreeCountriesOneCheckpoint";
            this.ClientSize = new Size(1000, 800);
            this.BackColor = Color.WhiteSmoke;
            this.MinimumSize = new Size(1000, 800);

            CreateUIWithTableLayout();

            _controller = new GameController();
            UpdateUI();
        }

        private void CreateUIWithTableLayout()
        {
            mainTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                BackColor = Color.Transparent
            };

            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            Panel topPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Green };
            mainTable.Controls.Add(topPanel, 0, 0);
            mainTable.SetColumnSpan(topPanel, 2);

            Panel leftPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.LightBlue };
            mainTable.Controls.Add(leftPanel, 0, 1);
            Panel leftBottomPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.RosyBrown };
            mainTable.Controls.Add(leftBottomPanel, 0, 2);
            Panel leftBottomBottomPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.RosyBrown };
            mainTable.Controls.Add(leftBottomBottomPanel, 0, 3);

            Panel rightPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Brown };
            mainTable.Controls.Add(rightPanel, 1, 1);
            mainTable.SetRowSpan(rightPanel, 3);

            AddControlsToleftBottomBottomPanel(leftBottomBottomPanel);
            AddControlsToLeftBottomPannel(leftBottomPanel);
            AddControlsToTopPanel(topPanel);
            AddControlsToLeftPanel(leftPanel);
            AddControlsToRightPanel(rightPanel);

            this.Controls.Add(mainTable);
        }

        private void AddControlsToleftBottomBottomPanel(Panel panel)
        {
            string originalImage2Path = "C:\\Users\\user\\source\\repos" +
                "\\ThreeCountriesOneCheckpoint\\Pictures\\priceBook.png";
            string alternateImage2Path = "C:\\Users\\user\\source\\repos" +
                "\\ThreeCountriesOneCheckpoint\\Pictures\\openBook-fotor-20250422221346.png";
            var doc2 = new SmoothDraggablePictureBox(originalImage2Path, alternateImage2Path)
            {
                Size = new Size(200, 200),
                Location = new Point(100, 50)
            };
            panel.Controls.Add(doc2);
        }

        private void AddControlsToTopPanel(Panel panel)
        {

        }

        private void AddControlsToLeftBottomPannel(Panel panel)
        {
            string originalImage1Path = "C:\\Users\\user\\source\\repos" +
                "\\ThreeCountriesOneCheckpoint\\Pictures\\currencyBook.png";
            string alternateImage1Path = "C:\\Users\\user\\source\\repos" +
                "\\ThreeCountriesOneCheckpoint\\Pictures\\pngwing.com.png";

            var doc1 = new SmoothDraggablePictureBox(originalImage1Path, alternateImage1Path)
            {
                Size = new Size(200, 200),
                Location = new Point(50, 50)
            };


            panel.Controls.Add(doc1);
        }

        private void AddControlsToLeftPanel(Panel panel)
        {
            boxShowImage = new PictureBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(panel.Width / 2, panel.Height / 2),
                Size = new Size(250, 250),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.FixedSingle
            };
            panel.Controls.Add(boxShowImage);

            lblDialogue = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(220, 20),
                Size = new Size(panel.Width - 40, 100),
                Text = "Диалог...",
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White
            };
            panel.Controls.Add(lblDialogue);

            btnAllow = new Button
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(20, 300),
                Size = new Size(120, 40),
                Text = "Продать честно",
                BackColor = Color.LightGreen,
                Font = new Font("Arial", 10)
            };
            btnAllow.Click += BtnAllow_Click;
            panel.Controls.Add(btnAllow);

            btnDeny = new Button
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(panel.Width - 50, panel.Height / 2),
                Size = new Size(120, 40),
                Text = "Обмануть",
                BackColor = Color.LightCoral,
                Font = new Font("Arial", 10)
            };
            btnDeny.Click += BtnDeny_Click;
            panel.Controls.Add(btnDeny);

            lblName = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(20, 240),
                AutoSize = true,
                Text = "Имя:",
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White
            };
            panel.Controls.Add(lblName);

            lblCountry = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(20, 270),
                AutoSize = true,
                Text = "Страна:",
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White
            };
            panel.Controls.Add(lblCountry);
        }

        private void AddControlsToRightPanel(Panel panel)
        {
        }

        private void UpdateUI()
        {
            var person = _controller.GetCurrentPerson();
            boxShowImage.Image = Image.FromFile(person.PhotoPath);

            lblName.Text = $"Имя: {person.Name}";
            lblCountry.Text = $"Страна: {person.Country}";
            lblDialogue.Text = person.Interact();
        }

        private void BtnAllow_Click(object sender, EventArgs e)
        {
            var person = _controller.GetCurrentPerson();
            if (_controller.CheckContraband(person))
            {
                MessageBox.Show("Контрабанда обнаружена!");
            }
            _controller.IteratePerson();
            UpdateUI();
        }

        private void BtnDeny_Click(object sender, EventArgs e)
        {
            _controller.IteratePerson();
            UpdateUI();
        }

    }
}



