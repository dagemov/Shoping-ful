using Shoping.Data.Entities;

namespace Shoping.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context=context;  
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckCountriesAsync();
        }
        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any() ){
                _context.Categories.Add(new Category { Name = "Tecnología"});
                _context.Categories.Add(new Category { Name = "Ropa" });
                _context.Categories.Add(new Category { Name = "Calzado" });
                _context.Categories.Add(new Category { Name = "Belleza" });
                _context.Categories.Add(new Category { Name = "Nutrición" });
                _context.Categories.Add(new Category { Name = "Apple" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { 
                    Name = "Colombia",States=new List<State>()
                    {
                        new State {
                            Name="Antioquia",
                            Cities=new List<City>()
                            {
                                new City {Name = "Medellin" },
                                new City {Name = "Rio negro" },
                                new City {Name = "Envigado" },
                                new City {Name = "Itagui" }
                            }
                        
                        },
                        new State { 
                            Name="Cundinamarca",
                            Cities=new List<City>()
                            {
                                new City {Name = "Bogota" },
                                new City {Name = "Villa vicencio" },
                                new City {Name = "Soacha" },
                                new City {Name = "Zipaquirá" }
                            }
                        }
                    }                     
                });
                _context.Countries.Add(new Country {
                    Name = "Usa",
                    States = new List<State>()
                    {
                         new State {
                            Name="New York",
                            Cities=new List<City>()
                            {
                                new City {Name = "connecticut" },
                                new City {Name = "El bronx" },
                                new City {Name = "Queens" },
                                new City {Name = "Brooklyn" }
                            }

                        },
                    }

                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
