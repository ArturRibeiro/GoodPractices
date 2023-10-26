namespace Pattern.Options
{
    public class ApplicationConfiguration
    {
        [Required(ErrorMessage = "PropertieName1")] public string PropertieName1 { get; set; }
        [Required(ErrorMessage = "PropertieName2")] public string PropertieName2 { get; set; }
        [Required(ErrorMessage = "PropertieName3")] public string PropertieName3 { get; set; }
    }
}