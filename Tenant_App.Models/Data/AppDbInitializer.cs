//using NABTEB_HR.Models.Domains.Account;
//using NABTEB_HR.Models.Domains.Document;
//using NABTEB_HR.Models.Domains.PositionDomain;
//using NABTEB_HR.Utilities.Document;
//using NABTEB_HR.Utilities.Permission;
//using NABTEB_HR.Utilities.Position;
//using NABTEB_HR.Utilities.Role;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore.Internal;
//using Microsoft.Extensions.DependencyInjection;
//using System;

//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace NABTEB_HR.Models.Data
//{
//    public class AppDbInitializer
//    {
//        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
//        {
//            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//            {
//                UserManager<User> userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
//                RoleManager<Role> roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
//                AppDbContext context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
//                context.Database.EnsureCreated();

//                // Seed Admin User
//                User adminUser = await userManager.FindByEmailAsync("admin@seed.com");
//                if (adminUser == null) 
//                { 
//                    adminUser = CreateAdminUser();
//                    await userManager.CreateAsync(adminUser);
//                }

//                // Seed Admin Role
//                Role adminRole = context.Roles.FirstOrDefault(x => x.Name == RoleUtils.ADMIN);
//                if (adminRole == null)
//                { 
//                    adminRole = CreateAdminRole();
//                    await roleManager.CreateAsync(adminRole);
//                    await userManager.AddToRoleAsync(adminUser, "admin");
//                }

//                // Seed Admin Permissions and RolePermissions
//                Permission manageContestants = context.Permissions.FirstOrDefault(x => x.PermissionCode == PermissionUtils.CONTESTANT);
//                if (manageContestants == null)
//                {
//                    manageContestants = CreatePermission("Manage Contestants", "CONTESTANT", "", "Contestant/Index");
//                    context.Permissions.Add(manageContestants);
                    
//                    RolePermission adminManageContestant = CreateRolePermission(adminRole.Id, manageContestants.Id);
//                    context.RolePermissions.Add(adminManageContestant);
//                }
//                else 
//                {
//                    if (!context.RolePermissions.Any(x => x.PermissionId == manageContestants.Id && x.RoleId == adminRole.Id))
//                    {
//                        RolePermission adminManageContestant = CreateRolePermission(adminRole.Id, manageContestants.Id);
//                        context.RolePermissions.Add(adminManageContestant);
//                    }
//                }

//                Permission ballotList = context.Permissions.FirstOrDefault(x => x.PermissionCode == PermissionUtils.BALLOT_LIST);
//                if (ballotList == null)
//                {
//                    ballotList = CreatePermission("Ballot List", "BALLOT_LIST", "", "Contestant/BallotList");
//                    context.Permissions.Add(ballotList);

//                    RolePermission adminBallotList = CreateRolePermission(adminRole.Id, ballotList.Id);
//                    context.RolePermissions.Add(adminBallotList);
//                }
//                else 
//                {
//                    if (!context.RolePermissions.Any(x => x.PermissionId == ballotList.Id && x.RoleId == adminRole.Id))
//                    {
//                        RolePermission adminBallotList = CreateRolePermission(adminRole.Id, ballotList.Id);
//                        context.RolePermissions.Add(adminBallotList);
//                    }
//                }

//                // Seed Document Type
//                DocumentType sponsorLetter = context.DocumentTypes.FirstOrDefault(x => x.Name == DocumentUtils.SPONSOR_LETTER);
//                if (sponsorLetter == null)
//                {
//                    sponsorLetter = new DocumentType() { Name = DocumentUtils.SPONSOR_LETTER };
//                    context.DocumentTypes.Add(sponsorLetter);
//                }

//                DocumentType coSponsorLetter = context.DocumentTypes.FirstOrDefault(x => x.Name == DocumentUtils.CO_SPONSOR_LETTER);
//                if (coSponsorLetter == null)
//                {
//                    coSponsorLetter = new DocumentType() { Name = DocumentUtils.CO_SPONSOR_LETTER };
//                    context.DocumentTypes.Add(coSponsorLetter);
//                }

//                DocumentType electoralCommitteeLetter = context.DocumentTypes.FirstOrDefault(x => x.Name == DocumentUtils.ELECTORAL_COMMITTEE_LETTER);
//                if (electoralCommitteeLetter == null)
//                {
//                    electoralCommitteeLetter = new DocumentType() { Name = DocumentUtils.ELECTORAL_COMMITTEE_LETTER };
//                    context.DocumentTypes.Add(electoralCommitteeLetter);
//                }

//                DocumentType otherDocument = context.DocumentTypes.FirstOrDefault(x => x.Name == DocumentUtils.OTHERS);
//                if (otherDocument == null)
//                {
//                    otherDocument = new DocumentType() { Name = DocumentUtils.OTHERS };
//                    context.DocumentTypes.Add(otherDocument);
//                }

//				//seed Position
//				Position position = context.Position.FirstOrDefault(x => x.Name == PositionUtils.PRESIDENT);
//				if (position == null)
//				{
//					position = new Position() { Name = PositionUtils.PRESIDENT };
//					context.Position.Add(position);
//				}

//                Position positionA = context.Position.FirstOrDefault(x => x.Name == PositionUtils.VICE_PRESIDENT);
//                if (positionA == null)
//                {
//                    positionA = new Position() { Name = PositionUtils.VICE_PRESIDENT };
//                    context.Position.Add(positionA);
//                }

//                Position positionB = context.Position.FirstOrDefault(x => x.Name == PositionUtils.SECRETARY_GENERAL);
//                if (positionB == null)
//                {
//                    positionB = new Position() { Name = PositionUtils.SECRETARY_GENERAL };
//                    context.Position.Add(positionB);
//                }

//                Position positionC = context.Position.FirstOrDefault(x => x.Name == PositionUtils.FINANCIAL_SECRETARY);
//                if (positionC == null)
//                {
//                    positionC = new Position() { Name = PositionUtils.FINANCIAL_SECRETARY };
//                    context.Position.Add(positionC);
//                }

//                Position positionD = context.Position.FirstOrDefault(x => x.Name == PositionUtils.TREASURER);
//                if (positionD == null)
//                {
//                    positionD = new Position() { Name = PositionUtils.TREASURER };
//                    context.Position.Add(positionD);
//                }






//                //DocumentUtils documentUtils = new DocumentUtils();
//                //PropertyInfo[] properties = documentUtils.GetType().GetProperties();

//                //foreach (var property in properties)
//                //{
//                //	var documentTypeName = (string)property.GetValue(documentUtils);

//                //	DocumentType existingDocumentType = context.DocumentTypes.FirstOrDefault(x => x.Name == documentTypeName);

//                //	if (existingDocumentType == null)
//                //	{
//                //		DocumentType newDocumentType = new DocumentType() { Name = documentTypeName };
//                //		context.DocumentTypes.Add(newDocumentType);
//                //	}
//                //}

//                //PositionUtils positionUtils = new PositionUtils();
//                //PropertyInfo[] positionProperties = positionUtils.GetType().GetProperties();

//                //foreach (var property in positionProperties)
//                //{
//                //	var positionName = (string)property.GetValue(positionUtils);

//                //	Position existingPosition = context.Position.FirstOrDefault(x => x.Name == positionName);

//                //	if (existingPosition == null)
//                //	{
//                //		Position newPosition = new Position() { Name = positionName };
//                //		context.Position.Add(newPosition);
//                //	}
//                //}


//                await context.SaveChangesAsync();
//            }
//        }

//        public static User CreateAdminUser()
//        {
//            User adminUser = new User()
//            {
//                Id = Guid.NewGuid().ToString(),
//                FirstName = "Admin",
//                LastName = "Seed",
//                Email = "admin@seed.com",
//                EmailConfirmed = true,
//                CreatedBy = "root",
//                UserName = "admin@seed.com"
//            };

//            PasswordHasher<User> password = new PasswordHasher<User>();
//            adminUser.PasswordHash = password.HashPassword(adminUser, "Password@1.");

//            return adminUser;
//        }

//        public static Role CreateAdminRole()
//        {
//            Role adminRole = new Role()
//            {
//                Id = Guid.NewGuid().ToString(),
//                Name = "admin",
//                RoleDescription = "This is the admin role.",
//                IsActive = true,
//                IsDeleted = false
//            };

//            return adminRole;
//        }

//        public static Permission CreatePermission(string permissionName, string permissionCode, string icon, string url)
//        {
//            return new Permission()
//            {
//                PermissionName = permissionName,
//                PermissionCode = permissionCode,
//                Icon = icon,
//                Url = url
//            };

//        }

//        public static RolePermission CreateRolePermission(string roleId, Guid permissionId)
//        {
//            return new RolePermission()
//            {
//                RoleId = roleId,
//                PermissionId = permissionId
//            };
//        }

//    }
//}
