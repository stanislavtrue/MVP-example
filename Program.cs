namespace MVP_Calculator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            var view = new Form1();
            var model = new Model();
            var presenter = new Presenter(view, model);
            Application.Run(view);
        }
    }
}