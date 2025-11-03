using System.Net.Mime;

namespace MVP_Calculator
{
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
}
