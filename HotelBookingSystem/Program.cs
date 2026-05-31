using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem
{
    // Step 1 - Create the Room Class
    class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public double PricePerNight { get; set; }
        public bool IsBooked { get; set; }
        public int Floor { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Step 2 - Create Sample Data
            List<Room> rooms = new List<Room>
            {
                new Room { Id = 1, RoomNumber = "101", Type = "Single", PricePerNight = 500, IsBooked = false, Floor = 1 },
                new Room { Id = 2, RoomNumber = "102", Type = "Double", PricePerNight = 800, IsBooked = true, Floor = 1 },
                new Room { Id = 3, RoomNumber = "201", Type = "Suite", PricePerNight = 1500, IsBooked = false, Floor = 2 },
                new Room { Id = 4, RoomNumber = "202", Type = "Single", PricePerNight = 550, IsBooked = true, Floor = 2 },
                new Room { Id = 5, RoomNumber = "301", Type = "Double", PricePerNight = 900, IsBooked = false, Floor = 3 },
                new Room { Id = 6, RoomNumber = "302", Type = "Suite", PricePerNight = 1700, IsBooked = true, Floor = 3 },
                new Room { Id = 7, RoomNumber = "401", Type = "Single", PricePerNight = 600, IsBooked = false, Floor = 4 },
                new Room { Id = 8, RoomNumber = "402", Type = "Double", PricePerNight = 950, IsBooked = false, Floor = 4 }
            };

            ExecuteRequiredTasks(rooms);
            ExecuteBonusTasks(rooms);
        }

        private static void ExecuteRequiredTasks(List<Room> rooms)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         REQUIRED LINQ OPERATIONS       ");
            Console.WriteLine("========================================");

            // 1. Get all available rooms using Where()
            Console.WriteLine("\n[1] Available Rooms:");
            var availableRooms = rooms.Where(r => !r.IsBooked);
            foreach (var room in availableRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} - {room.Type} (${room.PricePerNight})");
            }

            // 2. Display only room numbers using Select()
            Console.WriteLine("\n[2] Only Room Numbers:");
            var roomNumbers = rooms.Select(r => r.RoomNumber).ToList();
            foreach (var number in roomNumbers)
            {
                Console.WriteLine(number);
            }

            // 3. Get the first available suite room using FirstOrDefault()
            Console.WriteLine("\n[3] First Available Suite Room:");
            var firstAvailableSuite = rooms.FirstOrDefault(r => r.Type == "Suite" && !r.IsBooked);
            if (firstAvailableSuite != null)
            {
                Console.WriteLine($"Room {firstAvailableSuite.RoomNumber} - Price: ${firstAvailableSuite.PricePerNight}");
            }
            else
            {
                Console.WriteLine("No available suites found.");
            }

            // 4. Sort rooms by price using OrderBy()
            Console.WriteLine("\n[4] Rooms Sorted by Price (Ascending):");
            var sortedRoomsByPrice = rooms.OrderBy(r => r.PricePerNight).ToList();
            foreach (var room in sortedRoomsByPrice)
            {
                Console.WriteLine($"Room {room.RoomNumber}: ${room.PricePerNight}");
            }

            // 5. Count booked rooms using Count()
            Console.WriteLine("\n[5] Booked Rooms Count:");
            int bookedRoomsCount = rooms.Count(r => r.IsBooked);
            Console.WriteLine($"Total Booked Rooms: {bookedRoomsCount}");

            // 6. Calculate average room price using Average()
            Console.WriteLine("\n[6] Average Room Price:");
            double averagePrice = rooms.Average(r => r.PricePerNight);
            Console.WriteLine($"Average Price: ${averagePrice:F2}");

            // 7. Get the most expensive room using Max() / MaxBy()
            Console.WriteLine("\n[7] Most Expensive Room:");
            var mostExpensiveRoom = rooms.MaxBy(r => r.PricePerNight);
            if (mostExpensiveRoom != null)
            {
                Console.WriteLine($"Room {mostExpensiveRoom.RoomNumber} - {mostExpensiveRoom.Type} (${mostExpensiveRoom.PricePerNight})");
            }
        }

        private static void ExecuteBonusTasks(List<Room> rooms)
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("               BONUS TASKS              ");
            Console.WriteLine("========================================");

            // Bonus 1: Display rooms on a specific floor (e.g., Floor 2)
            Console.WriteLine("\n[Bonus 1] Rooms on Floor 2:");
            var floorRooms = rooms.Where(r => r.Floor == 2).ToList();
            foreach (var room in floorRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} on Floor {room.Floor}");
            }

            // Bonus 2: Search rooms by type (e.g., "Single")
            Console.WriteLine("\n[Bonus 2] Search results for 'Single' rooms:");
            var singleRooms = rooms.Where(r => r.Type.Equals("Single", StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var room in singleRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} - Booked: {room.IsBooked}");
            }

            // Bonus 3: Group rooms by type using GroupBy()
            Console.WriteLine("\n[Bonus 3] Group Rooms by Type:");
            var groupedRooms = rooms.GroupBy(r => r.Type);
            foreach (var group in groupedRooms)
            {
                Console.WriteLine($"Type: {group.Key} (Total: {group.Count()})");
                foreach (var room in group)
                {
                    Console.WriteLine($"  -> Room {room.RoomNumber} - ${room.PricePerNight}");
                }
            }

            // Bonus 4: Display available rooms sorted by price
            Console.WriteLine("\n[Bonus 4] Available Rooms Sorted by Price:");
            var sortedAvailableRooms = rooms.Where(r => !r.IsBooked).OrderBy(r => r.PricePerNight).ToList();
            foreach (var room in sortedAvailableRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} - ${room.PricePerNight}");
            }

            // Bonus 5: Find the cheapest room
            Console.WriteLine("\n[Bonus 5] Cheapest Room:");
            var cheapestRoom = rooms.MinBy(r => r.PricePerNight);
            if (cheapestRoom != null)
            {
                Console.WriteLine($"Room {cheapestRoom.RoomNumber} - ${cheapestRoom.PricePerNight}");
            }

            // Bonus 6: Find all rooms with price greater than 1000
            Console.WriteLine("\n[Bonus 6] Rooms with Price > 1000:");
            var luxuryRooms = rooms.Where(r => r.PricePerNight > 1000).ToList();
            foreach (var room in luxuryRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} ({room.Type}) - ${room.PricePerNight}");
            }
        }
    }
}