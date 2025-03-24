using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CustomerService.DTO;
using CustomerService.Service;

namespace CustomerService
{
    public class RegistrationManager : IRegistrationManager
    {
        private readonly List<RegistrationRequestDto> registeredUsers = new();

        public RegistrationResponseDto Register(RegistrationRequestDto request)
        {
            List<string> errors = new();

            // Check if all fields are empty
            if (string.IsNullOrWhiteSpace(request.Name) &&
                string.IsNullOrWhiteSpace(request.Email) &&
                string.IsNullOrWhiteSpace(request.Phone) &&
                string.IsNullOrWhiteSpace(request.City))
            {
                return new RegistrationResponseDto
                {
                    Success = false,
                    ErrorMessage = "All fields are required."
                };
            }

            // Special case: If Name and Email are both missing, return combined error
            if (string.IsNullOrWhiteSpace(request.Name) && string.IsNullOrWhiteSpace(request.Email))
            {
                return new RegistrationResponseDto
                {
                    Success = false,
                    ErrorMessage = "Name and Email are required."
                };
            }

            // Validate Name
            string trimmedName = request.Name?.Trim();
            if (string.IsNullOrEmpty(trimmedName) || trimmedName.Length < 2 || trimmedName.Length > 50)
                errors.Add("Name must be between 2 and 50 characters.");

            // Validate Email
            if (string.IsNullOrWhiteSpace(request.Email))
                errors.Add("Email is required.");
            else if (!IsValidEmail(request.Email))
                errors.Add("Invalid email format.");
            else if (registeredUsers.Any(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase)))
                errors.Add("Email already exists.");

            // Validate Phone (if provided)
            if (!string.IsNullOrEmpty(request.Phone) && !IsValidPhoneNumber(request.Phone))
                errors.Add("Invalid phone number format.");

            // Validate City (if provided)
            if (!string.IsNullOrEmpty(request.City) && (request.City.Length < 2 || request.City.Length > 50))
                errors.Add("City must be between 2 and 50 characters.");

            // If there are validation errors, return them
            if (errors.Count > 0)
            {
                return new RegistrationResponseDto
                {
                    Success = false,
                    ErrorMessage = string.Join(" ", errors)
                };
            }

            // If all validations pass, register the user
            registeredUsers.Add(request);

            return new RegistrationResponseDto
            {
                Id = Guid.NewGuid(),
                Success = true,
                ErrorMessage = null
            };
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            // Accepts international format (+1-234-567-8900) and standard digits
            return Regex.IsMatch(phone, @"^\+?[0-9\s\-\(\)]{7,20}$");
        }
    }
}
