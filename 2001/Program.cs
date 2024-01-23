using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//above is from template



public class ProfileDbContext : DbContext
{
    public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
        : base(options)
    {
    }




    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Trail> Trails { get; set; }
    public DbSet<Filter> Filters { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Completion> Completions { get; set; }
}// above is a list of tables in the database

public class Administrator
{
    public int AdminID { get; set; }
    public string AdminUsername { get; set; }
    public string AdminPassword { get; set; }
}// above is table with attributes for the admin table

public class Trail
{
    public int TrailID { get; set; }
    public string TrailName { get; set; }
    public float Length { get; set; }
    public float ElevationKM { get; set; }
    public DateTime RouteTime { get; set; }
    public string Accessibility { get; set; }
    public string RouteDesc { get; set; }
}// above is table with attributes for the trails table

public class Filter
{
    public int FilterID { get; set; }
    public string FilterName { get; set; }
}// above is table with attributes for the filters table

public class User
{
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string UserEmail { get; set; }
    public int FilterID { get; set; }
    public int TrailID { get; set; }
    public int Active { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string About { get; set; }
    public string Location { get; set; }
    public float Height { get; set; }
    public float Weight { get; set; }
    public DateTime DOB { get; set; }
    public Filter Filter { get; set; }
    public Trail Trail { get; set; }
}// above is table with attributes for the user table

public class Review
{
    public int ReviewID { get; set; }
    public int TrailID { get; set; }
    public int UserID { get; set; }
    public string ReviewName { get; set; }
    public string ReviewDesc { get; set; }
    public Trail Trail { get; set; }
    public User User { get; set; }
}// above is table with attributes for the reviews table

public class Photo
{
    public int PhotoID { get; set; }
    public int TrailID { get; set; }
    public int UserID { get; set; }
    public string PhotoName { get; set; }
    public byte[] PhotoImg { get; set; }
    public string PhotoDesc { get; set; }
    public Trail Trail { get; set; }
    public User User { get; set; }
}// above is table with attributes for the photos table

public class Completion
{
    public int CompID { get; set; }
    public int TrailID { get; set; }
    public int UserID { get; set; }
    public bool Completed { get; set; }
    public Trail Trail { get; set; }
    public User User { get; set; }
}// above is table with attributes for the completed trails table

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly ProfileDbContext _dbContext;

    public ProfilesController(ProfileDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        if (id != user.UserID)
        {
            return BadRequest();
        }

        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}