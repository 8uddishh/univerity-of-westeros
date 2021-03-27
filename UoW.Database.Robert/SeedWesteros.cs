namespace UoW.Database.Robert
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using UoW.Database.Robert.Entities;

    public static class SeedWesteros
    {
        public static void WinterIsComing(IApplicationBuilder app)
        {
            using(var svcScope = app.ApplicationServices.CreateScope())
            {
                PrepareForWinter(svcScope.ServiceProvider.GetService<WesterosContext>());
            }
        }

        private static void PrepareForWinter(WesterosContext context)
        {
            context.Database.Migrate();
            var hasAnyChanges = false;

            if (!context.ContactTypes.Any())
            {
                context.ContactTypes.AddRange(
                    new ContactType
                    {
                        Name = "Address",
                        Description = "Address of the person/organization"
                    },
                    new ContactType
                    {
                        Name = "Home Phone",
                        Description = "Main Phone of the person/organization"
                    },
                    new ContactType
                    {
                        Name = "Cell Phone",
                        Description = "Cell Phone of the person/organization"
                    },
                    new ContactType
                    {
                        Name = "Desk Phone",
                        Description = "Desk Phone of the person/organization"
                    },
                    new ContactType
                    {
                        Name = "Official Email",
                        Description = "Official email of the person/organization"
                    },
                    new ContactType
                    {
                        Name = "Personal Email",
                        Description = "Personal email of the person/organization"
                    },
                    new ContactType
                    {
                        Name = "Facebook",
                        Description = "Facebook url of the person/organization"
                    },
                    new ContactType
                    {
                        Name = "Twitter",
                        Description = "Twitter url of the person/organization"
                    },
                    new ContactType
                    {
                        Name = "Blog",
                        Description = "Blog url of the person/organization"
                    },
                    new ContactType
                    {
                        Name = "GitHub",
                        Description = "GitHub url of the person/organization"
                    }
                );
                hasAnyChanges |= true;
            }

            if (!context.Semesters.Any())
            {
                context.Semesters.AddRange(
                    new Semester
                    {
                        Name = "I",
                        Descriptiom = "Semester 1"
                    },
                    new Semester
                    {
                        Name = "II",
                        Descriptiom = "Semester 2"
                    },
                    new Semester
                    {
                        Name = "III",
                        Descriptiom = "Semester 3"
                    },
                    new Semester
                    {
                        Name = "IV",
                        Descriptiom = "Semester 4"
                    },
                    new Semester
                    {
                        Name = "V",
                        Descriptiom = "Semester 5"
                    },
                    new Semester
                    {
                        Name = "VI",
                        Descriptiom = "Semester 6"
                    },
                    new Semester
                    {
                        Name = "VII",
                        Descriptiom = "Semester 1"
                    },
                    new Semester
                    {
                        Name = "VIII",
                        Descriptiom = "Semester 8"
                    },
                    new Semester
                    {
                        Name = "IX",
                        Descriptiom = "Semester 9"
                    },
                    new Semester
                    {
                        Name = "X",
                        Descriptiom = "Semester 10"
                    }
                );
                hasAnyChanges |= true;
            }

            if (hasAnyChanges)
                context.SaveChanges();
        }
    }
}
