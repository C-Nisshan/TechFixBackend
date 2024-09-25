using TechFixBackend.Data;
using TechFixBackend.Models;
using System.Threading.Tasks;
using System;
using TechFixBackend.DTOs;
using TechFixBackend.Utils;

namespace TechFixBackend.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get a user by their ID
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            // Check if the userId is valid
            if (userId <= 0)
            {
                throw new ArgumentException("User ID must be greater than zero.", nameof(userId));
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            return user;
        }

        // Update user details 
        public async Task UpdateUserAsync(int userId, UserUpdateDTO userDto)
        {
            var existingUser = await _context.Users.FindAsync(userId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            // Update the user details from the DTO
            existingUser.Username = userDto.Username;
            existingUser.Role = userDto.Role;

            // If a new password is provided, hash and update it
            if (!string.IsNullOrEmpty(userDto.NewPassword))
            {
                existingUser.PasswordHash = PasswordHasher.HashPassword(userDto.NewPassword);
            }

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
        }
    }
}
