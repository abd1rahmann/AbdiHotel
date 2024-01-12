﻿using AbdiHotelConsole.Data;
using AbdiHotelConsole.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelConsole.GuestRepository
{
    public class ReActive
    {
        private readonly ApplicationDbContext _dbContext;
        public ReActive(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void ReActivateGuest() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Återaktivering av gäst");
            Console.ResetColor();
            Console.WriteLine("====================================================================================");

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");
            string back = Console.ReadLine();
            if (back == "1")
            {
                Console.Clear();
                var backTo = new GuestMenu();
                backTo.GuestMenuChoice();
            }

            Console.WriteLine("Välj ID på gästen du vill återaktivera:");

            var activeGuests = _dbContext.Guest.Where(g => g.IsActive == false).ToList();
            foreach (var guest in activeGuests)
            {
                Console.WriteLine($"\nID: {guest.GuestId}");
                Console.WriteLine($"Förnamn: {guest.GuestFirstName}");
                Console.WriteLine($"Efternamn: {guest.GuestLastName}");
                Console.WriteLine($"Email: {guest.GuestEmail}");
                Console.WriteLine($"Address: {guest.Address}\n========================\n");
            }
            Console.WriteLine("\nVälj ID på gästen du vill återaktivera:");

            int guestIdToReActive = Convert.ToInt32( Console.ReadLine());

            var guestToReActive = _dbContext.Guest.FirstOrDefault(g => g.GuestId == guestIdToReActive);

            guestToReActive.IsActive = true;

            _dbContext.SaveChanges();

            Console.WriteLine("\nGästen är nu återaktiverad!!");
            Console.ReadLine();

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();

        }
    }
}