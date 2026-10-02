using Microsoft.EntityFrameworkCore;
using OrganizationAssetManagement.Domain.Entities;
using OrganizationAssetManagement.Domain.Enums;

namespace OrganizationAssetManagement.Infrastructure.Persistence.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Fixed IDs for easy Swagger testing
        var headOfficeId =
            Guid.Parse("11111111-1111-1111-1111-111111111111");

        var itDepartmentId =
            Guid.Parse("22222222-2222-2222-2222-222222222222");

        var adminId =
            Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        var managerId =
            Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

        var viewerId =
            Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

        var laptopId =
            Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

        var monitorId =
            Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

        var printerId =
            Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");


        // ------------------------------------------------
        // ORGANIZATION UNITS
        // ------------------------------------------------

        var headOfficeExists =
            await context.OrganizationUnits.AnyAsync(x =>
                x.Id == headOfficeId);

        if (!headOfficeExists)
        {
            var headOffice = new OrganizationUnit
            {
                Id = headOfficeId,
                Name = "Head Office",
                Description = "Main organization office",
                CreatedAt = DateTime.UtcNow
            };

            await context.OrganizationUnits.AddAsync(headOffice);
            await context.SaveChangesAsync();
        }


        var itDepartmentExists =
            await context.OrganizationUnits.AnyAsync(x =>
                x.Id == itDepartmentId);

        if (!itDepartmentExists)
        {
            var itDepartment = new OrganizationUnit
            {
                Id = itDepartmentId,
                Name = "IT Department",
                Description = "Information Technology Department",
                ParentOrganizationUnitId = headOfficeId,
                CreatedAt = DateTime.UtcNow
            };

            await context.OrganizationUnits.AddAsync(itDepartment);
            await context.SaveChangesAsync();
        }


        // ------------------------------------------------
        // USERS
        // ------------------------------------------------

        var adminExists =
            await context.Users.AnyAsync(x =>
                x.Id == adminId ||
                x.Email == "admin@example.com");

        if (!adminExists)
        {
            var admin = new User
            {
                Id = adminId,
                FirstName = "System",
                LastName = "Administrator",
                Email = "admin@example.com",
                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Role = UserRole.Administrator,
                OrganizationUnitId = headOfficeId,
                CreatedAt = DateTime.UtcNow
            };

            await context.Users.AddAsync(admin);
            await context.SaveChangesAsync();
        }


        var managerExists =
            await context.Users.AnyAsync(x =>
                x.Id == managerId ||
                x.Email == "manager@example.com");

        if (!managerExists)
        {
            var manager = new User
            {
                Id = managerId,
                FirstName = "IT",
                LastName = "Manager",
                Email = "manager@example.com",
                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword("Manager123!"),
                Role = UserRole.Manager,
                OrganizationUnitId = itDepartmentId,
                CreatedAt = DateTime.UtcNow
            };

            await context.Users.AddAsync(manager);
            await context.SaveChangesAsync();
        }


        var viewerExists =
            await context.Users.AnyAsync(x =>
                x.Id == viewerId ||
                x.Email == "viewer@example.com");

        if (!viewerExists)
        {
            var viewer = new User
            {
                Id = viewerId,
                FirstName = "Test",
                LastName = "Viewer",
                Email = "viewer@example.com",
                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword("Viewer123!"),
                Role = UserRole.Viewer,
                OrganizationUnitId = itDepartmentId,
                CreatedAt = DateTime.UtcNow
            };

            await context.Users.AddAsync(viewer);
            await context.SaveChangesAsync();
        }


        // ------------------------------------------------
        // ASSETS
        // ------------------------------------------------

        var laptopExists =
            await context.Assets.AnyAsync(x =>
                x.Id == laptopId ||
                x.AssetTag == "ASSET-001");

        if (!laptopExists)
        {
            var laptop = new Asset
            {
                Id = laptopId,
                Name = "Dell Laptop",
                AssetTag = "ASSET-001",
                SerialNumber = "DELL-001",
                Description =
                    "Dell laptop used by the IT department",
                Status = AssetStatus.Available,
                OrganizationUnitId = itDepartmentId,
                CreatedAt = DateTime.UtcNow
            };

            await context.Assets.AddAsync(laptop);
            await context.SaveChangesAsync();
        }


        var monitorExists =
            await context.Assets.AnyAsync(x =>
                x.Id == monitorId ||
                x.AssetTag == "ASSET-002");

        if (!monitorExists)
        {
            var monitor = new Asset
            {
                Id = monitorId,
                Name = "HP Monitor",
                AssetTag = "ASSET-002",
                SerialNumber = "HP-002",
                Description =
                    "HP monitor used by the IT department",
                Status = AssetStatus.Available,
                OrganizationUnitId = itDepartmentId,
                CreatedAt = DateTime.UtcNow
            };

            await context.Assets.AddAsync(monitor);
            await context.SaveChangesAsync();
        }


        var printerExists =
            await context.Assets.AnyAsync(x =>
                x.Id == printerId ||
                x.AssetTag == "ASSET-003");

        if (!printerExists)
        {
            var printer = new Asset
            {
                Id = printerId,
                Name = "Office Printer",
                AssetTag = "ASSET-003",
                SerialNumber = "PRINTER-003",
                Description =
                    "Printer used by Head Office",
                Status = AssetStatus.Available,
                OrganizationUnitId = headOfficeId,
                CreatedAt = DateTime.UtcNow
            };

            await context.Assets.AddAsync(printer);
            await context.SaveChangesAsync();
        }
    }
}