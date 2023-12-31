﻿namespace HotelProject.WebUI.Dtos.RoomDto
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; } //Harf+Metinsel Değerler Alabilir.
        public string RoomCoverImage { get; set; }
        public int Price { get; set; } //Sıralama olabilir.
        public string Title { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
