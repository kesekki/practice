using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace computerTech
{
    public partial class Autorization : Form
    {
        public string connectionString = "Server=ADCLG1;Database=computerEquipmentRequests;Trusted_Connection=True;TrustServerCertificate=true;"; public string currentCapcha;
        private int failedAttempts = 0;
        private Timer timer1;
        private bool isBlocked = false;

        public Autorization()
        {
            InitializeComponent();
            textBoxPasswd.UseSystemPasswordChar = true;

            blockTimer = new Timer();
            blockTimer.Interval = 180000;
            blockTimer.Tick += timer1_Tick;


        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            if (isBlocked)
            {
                MessageBox.Show("Вход заблокирован. Пожалуйста, подождите 3 минуты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string login = textBoxLogin.Text;
            string password = textBoxPasswd.Text;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pictureBoxCapcha.Visible && !CheckCapcha(textBoxCapcha.Text))
            {
                MessageBox.Show("Неверная капча. Пожалуйста, попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Попытка аутентификации
            if (AuthenticateUser(login, password, out int userTypeId, out int userId))
            {
                OpenMainForm(userTypeId, userId);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                failedAttempts++;

                if (failedAttempts == 1)
                {
                    ShowCapcha();
                }
                // Блокируем вход после первой неудачной попытки
                if (failedAttempts >= 2)
                {
                    isBlocked = true;
                    blockTimer.Start();
                    MessageBox.Show("Вы превысили количество попыток входа. Вход заблокирован на 3 минуты.", "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ClearInputFields();
            }
        }

        private bool CheckCapcha(string inputCapcha)
        {
            return string.Equals(inputCapcha, currentCapcha, StringComparison.OrdinalIgnoreCase);
        }
        private void ClearInputFields()
        {
            textBoxLogin.Clear(); // Очищаем поле логина
            textBoxPasswd.Clear(); // Очищаем поле пароля
            textBoxCapcha.Clear(); // Очищаем поле капчи
        }
        private void CheckFailedAttempts()
        {
            if (failedAttempts > 1)
            {
                isBlocked = true;
                blockTimer.Start();
                MessageBox.Show("Вы превысили количество попыток входа. Вход заблокирован на 3 минуты.", "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool AuthenticateUser(string login, string password, out int userTypeId, out int userId)
        {
            userTypeId = -1;
            userId = -1;
            bool isSuccessful = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT userTypeID, userID FROM Users WHERE login = @login AND password = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password); // В реальном приложении пароли должны храниться в зашифрованном виде

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        userId = reader.GetInt32(1);
                        userTypeId = reader.GetInt32(0);
                        isSuccessful = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                }
            }

            RecordLoginHistory(login, isSuccessful);
            return isSuccessful;
        }

        private void RecordLoginHistory(string login, bool isSuccessful)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO LoginHistory (login, attemptTime, isSuccessful) VALUES (@login, @time, @isSuccessful)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@time", DateTime.Now);
                command.Parameters.AddWithValue("@isSuccessful", isSuccessful);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при записи истории входа: " + ex.Message);
                }
            }
        }


        private void OpenMainForm(int userTypeId, int userId)
        {
            Form mainForm = null;

            switch (userTypeId)
            {
                case 1:
                    mainForm = new ManagerMain();
                    break;
                case 2:
                    mainForm = new MasterFirst(userId);
                    break;
                case 3:
                    mainForm = new CustomerFirst(userId);
                    break;
                case 4:
                    mainForm = new OperatorFirst(userId);
                    break;
                default:
                    MessageBox.Show("Неизвестный тип пользователя.");
                    return;
            }

            mainForm.Show();
            this.Hide();
        }

        private void ShowCapcha()
        {
            labelcapcha.Visible = true;
            textBoxCapcha.Visible = true;
            pictureBoxCapcha.Visible = true;
            buttonCapcha.Visible = true;

            GenerateCapcha();
        }
        private string GenerateString()
        {
            Random random = new Random();
            const string chars = "abcdefghirstuvwxyzABCDEFGHRSTUVWXYZ0123456789";
            currentCapcha = new string(Enumerable.Repeat(chars, 4)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return currentCapcha;
        }
        private void GenerateCapcha()
        {
            Random random = new Random();
            Bitmap capchaImage = new Bitmap(180, 80); // Устанавливаем размер изображения
            using (Graphics g = Graphics.FromImage(capchaImage))
            {
                g.Clear(Color.White);

                // Добавление шума: линии и точки
                for (int i = 0; i < 40; i++) // Генерация случайных линий
                {
                    g.DrawLine(new Pen(Color.LightGray, 2), random.Next(0, 180), random.Next(0, 80), random.Next(0, 180), random.Next(0, 80));
                }

                using (Font font = new Font("Arial", 12, FontStyle.Bold))
                {
                    // Рисуем символы капчи с наклоном и случайным смещением
                    for (int i = 0; i < GenerateString().Length; i++)
                    {
                        float angle = random.Next(-4, 4); // Угол наклона
                        g.RotateTransform(angle);
                        g.DrawString(GenerateString()[i].ToString(), font, Brushes.Black, new PointF(10 + (i * 40) + random.Next(-5, 5), 20 + random.Next(-5, 5)));
                        g.RotateTransform(-angle); // Возвращаем графику в исходное состояние
                    }
                }
            }
            pictureBoxCapcha.Image = capchaImage;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (textBoxPasswd.UseSystemPasswordChar)
            {
                textBoxPasswd.UseSystemPasswordChar = false; // Показываем пароль
            }
            else
            {
                textBoxPasswd.UseSystemPasswordChar = true; // Скрываем пароль
            }
        }

        private void buttonCapcha_Click(object sender, EventArgs e)
        {
            GenerateCapcha();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            isBlocked = false;
            failedAttempts = 0; // Сбросить счетчик неудачных попыток
            blockTimer.Stop();
            MessageBox.Show("Блокировка снята. Вы можете попробовать снова войти.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            History HistoryForm = new History();
            HistoryForm.Show();
            this.Hide();
        }
    }
}
