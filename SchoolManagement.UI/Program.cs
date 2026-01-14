namespace SchoolManagement.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
         
            ApplicationConfiguration.Initialize();
            
          
            Application.SetDefaultFont(new Font("Segoe UI", 9F));
            
          
            Application.Run(new LoginForm());
        }
    }
}