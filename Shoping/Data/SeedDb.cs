using Shoping.Data.Entities;
using Shoping.Enums;
using Shoping.Helpers;

namespace Shoping.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context=context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Sebastian", "Martinez", "sebcos@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.Admin);

        }

        private async Task<User> CheckUserAsync(
             string document,
             string firstName,
             string lastName,
             string email,
             string phone,
             string address,
             UserType userType)
                {
                    User user = await _userHelper.GetUserAsync(email);
                    if (user == null)
                    {
                        user = new User
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            UserName = email,
                            PhoneNumber = phone,
                            Address = address,
                            Document = document,
                            City = _context.Cities.FirstOrDefault(),
                            UserType = userType,
                        };

                        await _userHelper.AddUserAsync(user, "123456");
                        await _userHelper.AddUserToRoleAsync(user, userType.ToString());
                    }

                return user;
        }



        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

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
