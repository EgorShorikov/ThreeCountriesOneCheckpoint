using System;
using System.Drawing;
using System.Windows.Forms;
using ThreeCountriesOneCheckpoint.Models;
using ThreeCountriesOneCheckpoint.Controler;

namespace ThreeCountriesOneCheckpoint.Views
{
    // Класс формы НЕ partial, т.к. Designer.cs не используется
    public class MainForm : Form
    {
        // Элементы управления
        private Label lblName;
        private Label lblCountry;
        private Label lblDialogue;
        private Button btnAllow;
        private Button btnDeny;
        private PictureBox boxShowImage;
        private PictureBox boxBackground;

        private GameController _controller;

        public MainForm()
        {
            // Настройка формы
            this.Text = "Рыбный КПП";
            this.ClientSize = new Size(400, 350);
            this.BackColor = Color.WhiteSmoke;

            // Создаем элементы вручную
            CreateUI();

            // Инициализация контроллера
            _controller = new GameController();
            UpdateUI();
        }

        private void CreateUI()
        {
            // Метка для имени
            lblName = new Label
            {
                AutoSize = true,
                Location = new Point(600, 600),
                Text = "Имя:",
                Font = new Font("Arial", 12)
            };
            this.Controls.Add(lblName);

            // Метка для страны
            lblCountry = new Label
            {
                AutoSize = true,
                Location = new Point(600, 650),
                Text = "Страна:",
                Font = new Font("Arial", 12)
            };
            this.Controls.Add(lblCountry);

            // Метка для диалога
            lblDialogue = new Label
            {
                AutoSize = true,
                Location = new Point(50, 150),
                Size = new Size(300, 60),
                Text = "Диалог...",
                Font = new Font("Arial", 10)
            };
            this.Controls.Add(lblDialogue);

            // Кнопка "Пропустить"
            btnAllow = new Button
            {
                Location = new Point(50, 250),
                Size = new Size(120, 40),
                Text = "Пропустить",
                BackColor = Color.LightGreen
            };
            btnAllow.Click += BtnAllow_Click;
            this.Controls.Add(btnAllow);

            // Кнопка "Отказать"
            btnDeny = new Button
            {
                Location = new Point(200, 250),
                Size = new Size(120, 40),
                Text = "Отказать",
                BackColor = Color.LightCoral
            };
            btnDeny.Click += BtnDeny_Click;
            this.Controls.Add(btnDeny);

            boxShowImage = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,  // Важно для пропорционального отображения
                Size = new Size(200, 200),           // Фиксированный размер
                //Location = new Point(200, 0),       // Позиция справа от текста
                //BorderStyle = BorderStyle.FixedSingle // Рамка для наглядности
            };
            this.Controls.Add(boxShowImage);

            // Увеличиваем размер формы, чтобы вместить PictureBox
            //this.ClientSize = new Size(500, 350);
        }

        private void UpdateUI()
        {
            var person = _controller.GetCurrentPerson();
            var path = Image.FromFile(person.PhotoPath);
            boxShowImage.Image = path;
            boxShowImage.Location = new Point(150,500); 
            lblName.Text = $"Имя: {person.Name}";
            lblCountry.Text = $"Страна: {person.Country}";
            lblDialogue.Text = person.Interact();
        }

        private void BtnAllow_Click(object sender, EventArgs e)
        {
            // Логика пропуска
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
            // Логика отказа
            _controller.IteratePerson();
            UpdateUI();
        }
    }
}