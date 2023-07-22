using TuTor_cho_nguoi_than.View.QuanLySinhVien;

namespace TuTor_cho_nguoi_than
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Data Source=PHAMDUCHOANG\SQLEXPRESS;Initial Catalog=TUTOR_CHO_NGUOI_THAN;Integrated Security=True;TrustServerCertificate=true
            //Scaffold-DbContext 'Data Source=PHAMDUCHOANG\SQLEXPRESS;Initial Catalog=TUTOR_CHO_NGUOI_THAN;Integrated Security=True;TrustServerCertificate=true' Microsoft.EntityFrameworkCore.SqlServer -OutputDir DomainClass -context DBContext -Contextdir Context -DataAnnotations -Force
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new QuanLySinhVien());
        }
    }
}