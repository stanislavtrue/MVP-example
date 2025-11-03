namespace MVP_Calculator
{
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
}
