using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Platforms.Add(plat);
        }
        public void UpdatePlatform(Platform plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Platforms.Update(plat);
        }
        
        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public bool UpdateChanges()
        {
            return ( _context.SaveChanges() >=0);
        }
        public bool DeletePlatform(int id)
        {
             var plat = _context.Platforms.FirstOrDefault(p => p.Id == id);
             var res = _context.Platforms.Remove(plat);
             Console.WriteLine(res);
             return ( _context.SaveChanges() >=0);
        }

    }
}