# Model-View-Presenter (MVP)
## Опис
**MVP** - це модель проєктування архітектури програмного забезпечення, яка вперше була представлена у 1990-х роках. Цей шаблон схожий на архітектуру **MVC**, але **Presenter** замінює **Controller**. **Presenter** несе відповідальність за зв'язок даних між **Model** та **View**. Нижче наведено ілюстрацію того, як **Model** і **View** передають дані через **Presenter**.
![](https://github.com/user-attachments/assets/e1819e7a-0115-45f6-89f9-eb3f70d656c7)
### Model
**Model** відповідає за отримання та зберігання даних у базах даних за допомогою API. Він інкапсулює операції з базами даних, мережеві комунікації та іншу логіку, пов'язану з бізнесом. Логіка основного додатка полягає в моделі, незалежній від інтерфейсу користувача.
### View
**View** не містить бізнес-логіки і відповідає за відображення елементів інтерфейсу користувача, з якими взаємодіє користувач. Він відображає дані з **Model** у візуально привабливому форматі, відстежує діяльність користувачів і надсилає їх **Presenter**.
### Presenter
**Presenter** є проміжним між **View** і **Model**, відповідальною за передачу даних. **Presenter** бере вхід користувача з подання і виконує обробку на ньому. Потім він взаємодіє з **Model** для оновлення або отримання даних. Він також відповідає за зміну погляду в залежності від змін, викликаних **Model**.
## Переваги MVP
Переваги, які надає архітектура MVP:
+ **Розділення проблем**: MVP розділяє обов'язки з управління даними, бізнес-логіки та візуалізації інтерфейсу користувача, що підвищує модульність коду та ремонтопридатність.
+ **Тестованість**: MVP сприяє перевіреності, роз'єднуючи компоненти. Розробники можуть проводити модульне тестування окремо на **Model**, **View** та **Presenter**, що полегшує та прискорює тестування.
+ **Повторне використання коду**: За допомогою MVP розробники можуть повторно використовувати бізнес-логіку в **Presenter** та операції з маніпулювання даними в **Model** в різних **View**. Це підвищує ефективність коду і зменшує надмірність.
+ **Покращена співпраця**: Поділ проблем у MVP дозволяє паралельно розвиватися між дизайнерами інтерфейсу користувача та розробниками. Дизайнери інтерфейсу користувача можуть зосередитися на створенні системних поглядів, поки розробники працюють над основною бізнес-логікою в **Presenter** та управлінням даними в **Model**.

MVP зазвичай використовується в додатках Windows Forms і ASP.NET форми додатків. Вибір шаблону проектування архітектури програмного забезпечення залежить від вимог системи.
## Приклад
### Опис
В цьому прикладі реалізовано простий калькулятор з однією операцією додавання.
### Компоненти
#### Model
Відповідає лише за логіку додавання, але не взаємодіє з користувачем.
```charp
public class Model
{
    public double Add(double a, double b)
    {
        return a + b;
    }
}
```
#### View
Не містить логіки обчислень, а лише показує дані користувачу.
```csharp
public partial class Form1 : Form
{
    private TextBox FirstNumberText;
    private TextBox SecondNumberText;
    private Button CalculateButton;
    private Label ResultLabel;
    private Label Plus;

    public string FirstNumber => FirstNumberText.Text;
    public string SecondNumber => SecondNumberText.Text;

    public string Result { set => ResultLabel.Text = value; }

    public event EventHandler AddClicked;
    
    public Form1()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(300, 200);
        this.Text = "Calculator";

        FirstNumberText = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 20 };
        SecondNumberText = new TextBox { Location = new System.Drawing.Point(80, 20), Width = 20 };
        CalculateButton = new Button
            { Text = "=", Location = new System.Drawing.Point(110, 20), Width = 20 };
        ResultLabel = new Label { Location = new System.Drawing.Point(140, 20), AutoSize = true };
        Plus = new Label { Text = "+", Location = new System.Drawing.Point(50, 20), Width = 20};

        CalculateButton.Click += (s, e) => AddClicked?.Invoke(this, EventArgs.Empty);

        this.Controls.Add(FirstNumberText);
        this.Controls.Add(SecondNumberText);
        this.Controls.Add(CalculateButton);
        this.Controls.Add(ResultLabel);
        this.Controls.Add(Plus);
    }
}
```
#### Presenter
Відповідає за керування логікою взаємодії між View та Model.
```csharp
public class Presenter
{
    private Model model;
    private Form1 view;

    public Presenter(Form1 view, Model model)
    {
        this.view = view;
        this.model = model;
        view.AddClicked += OnAddClicked;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        if (double.TryParse(view.FirstNumber, out double a) && double.TryParse(view.SecondNumber, out double b))
        {
            view.Result = $"{model.Add(a, b)}";
        }
        else
        {
            view.Result = "Error";
        }
    }
}
```
#### Результат роботи
![](https://github.com/user-attachments/assets/865d0d9e-d6e1-4a64-ba01-e82b752a8592)
