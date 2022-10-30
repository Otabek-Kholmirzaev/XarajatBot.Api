using Microsoft.AspNetCore.Mvc;
using XarajatBot.Api.Data;
using XarajatBot.Api.Entities;
using XarajatBot.Api.Models;

namespace XarajatBot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly XarajatDbContext _context;
    public UsersController(XarajatDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<UserEntity> GetUsers()
    {
        List<UserEntity> users = _context.Users.ToList();
        return users;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public UserEntity AddUser(CreateUserModel createUserModel)
    {
        var userEntity = new UserEntity
        {
            Name = createUserModel.Name,
            Email = createUserModel.Email,
            Phone = createUserModel.Phone,
            CreatedDate = DateTime.Now
        };
        _context.Users.Add(userEntity);
        _context.SaveChanges();
        return userEntity;
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateUser(int id, UpdateUserModel updateUserModel)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Id == id);
        if (userEntity == null)
        {
            return NotFound();
        }
        userEntity.Name = updateUserModel.Name;
        userEntity.Email = updateUserModel.Email;
        userEntity.Phone = updateUserModel.Phone;
        _context.SaveChanges();
        return Ok(userEntity);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return Ok(user);
    }

}