﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage = "Lütfen oda numarasını yazınız")]
        public string RoomNumber { get; set; } //Harf+Metinsel Değerler Alabilir.
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz")]
        public int Price { get; set; } //Sıralama olabilir.
        [Required(ErrorMessage = "Lütfen oda başlığı bilgisi giriniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen yatak sayısı bilgisi giriniz")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen banyo sayısı bilgisi giriniz")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}