namespace HotelProject.WebUI.Dtos.AboutDto
{
    public class UpdateAboutDto
    {
        //Yaptokları işler farklı olduğundan içerik aynı olsada farklı alanlarda tutulmalıdır.
        public int AboutID { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Content { get; set; }
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
