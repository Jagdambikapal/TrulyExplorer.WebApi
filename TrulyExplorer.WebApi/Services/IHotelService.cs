using System;
using System.Collections.Generic;
using TrulyExplorer.WebApi.HotelDto;
using TrulyExplorer.WebApi.Models;

public interface IHotelService
{
    IEnumerable<HotelDTO> GetAllHotels();
    void AddHotel(Hotel hotel);
    void UpdateHotel(Hotel hotel);
    void DeleteHotel(int id);
    List<Hotel> SearchHotels(string location, DateTime date, int numberOfAdults);
}
