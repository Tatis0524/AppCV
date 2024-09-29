using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCV
{
    public class CV
    {
        public string PersonalInfo { get; set; }
        public List<string> WorkExperience { get; set; } = new List<string>();
        public List<string> Education { get; set; } = new List<string>();
        public List<string> Skills { get; set; } = new List<string>();
        public List<string> Projects { get; set; } = new List<string>();
        public List<string> References { get; set; } = new List<string>();

        public void DisplayConsole()
        {
            Console.WriteLine("Curriculum Vitae");
            Console.WriteLine("----------------");
            Console.WriteLine("Personal Information:");
            Console.WriteLine(PersonalInfo);
            Console.WriteLine("\nWork Experience:");
            foreach (var exp in WorkExperience)
            {
                Console.WriteLine("- " + exp);
            }
            Console.WriteLine("\nEducation:");
            foreach (var edu in Education)
            {
                Console.WriteLine("- " + edu);
            }
            Console.WriteLine("\nSkills:");
            foreach (var skill in Skills)
            {
                Console.WriteLine("- " + skill);
            }
            Console.WriteLine("\nProjects:");
            foreach (var project in Projects)
            {
                Console.WriteLine("- " + project);
            }
            Console.WriteLine("\nReferences:");
            foreach (var reference in References)
            {
                Console.WriteLine("- " + reference);
            }
        }
    }

    public interface CVBuilder
    {
        void Reset();
        void SetPersonalInfo(string info);
        void AddWorkExperience(string experience);
        void AddEducation(string education);
        void AddSkills(string skill);
        void AddProjects(string project);
        void AddReferences(string reference);
        CV GetProduct();
    }

    public class CVBuilderCronologico : CVBuilder
    {
        private CV _cv;

        public CVBuilderCronologico()
        {
            this.Reset();
        }

        public void Reset()
        {
            _cv = new CV();
        }

        public void SetPersonalInfo(string info)
        {
            _cv.PersonalInfo = info;
        }

        public void AddWorkExperience(string experience)
        {
            _cv.WorkExperience.Add(experience);
        }

        public void AddEducation(string education)
        {
            _cv.Education.Add(education);
        }

        public void AddSkills(string skill)
        {
            _cv.Skills.Add(skill);
        }

        public void AddProjects(string project)
        {
            _cv.Projects.Add(project);
        }

        public void AddReferences(string reference)
        {
            _cv.References.Add(reference);
        }

        public CV GetProduct()
        {
            CV product = _cv;
            this.Reset();
            return product;
        }
    }

    public class CVBuilderFuncional : CVBuilder
    {
        private CV _cv;

        public CVBuilderFuncional()
        {
            this.Reset();
        }

        public void Reset()
        {
            _cv = new CV();
        }

        public void SetPersonalInfo(string info)
        {
            _cv.PersonalInfo = info;
        }

        public void AddWorkExperience(string experience)
        {
            // En el CV funcional, la experiencia laboral no es prioritaria, por lo que no se usa.
        }

        public void AddEducation(string education)
        {
            _cv.Education.Add(education);
        }

        public void AddSkills(string skill)
        {
            _cv.Skills.Add(skill);
        }

        public void AddProjects(string project)
        {
            _cv.Projects.Add(project);
        }

        public void AddReferences(string reference)
        {
            _cv.References.Add(reference);
        }

        public CV GetProduct()
        {
            CV product = _cv;
            this.Reset();
            return product;
        }
    }

    public class CVBuilderCreativo : CVBuilder
    {
        private CV _cv;

        public CVBuilderCreativo()
        {
            this.Reset();
        }

        public void Reset()
        {
            _cv = new CV();
        }

        public void SetPersonalInfo(string info)
        {
            _cv.PersonalInfo = info + " (Creative Professional)";
        }

        public void AddWorkExperience(string experience)
        {
            _cv.WorkExperience.Add("Creative Experience: " + experience);
        }

        public void AddEducation(string education)
        {
            _cv.Education.Add("Creative Education: " + education);
        }

        public void AddSkills(string skill)
        {
            _cv.Skills.Add("Creative Skill: " + skill);
        }

        public void AddProjects(string project)
        {
            _cv.Projects.Add("Creative Project: " + project);
        }

        public void AddReferences(string reference)
        {
            _cv.References.Add("Creative Reference: " + reference);
        }

        public CV GetProduct()
        {
            CV product = _cv;
            this.Reset();
            return product;
        }
    }


    public class GeneradorCV
    {
        private CVBuilder _builder;

        public void SetBuilder(CVBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructCVCompleto(string personalInfo, List<string> experiences, List<string> educations, List<string> skills, List<string> projects, List<string> references)
        {
            _builder.SetPersonalInfo(personalInfo);

            foreach (var exp in experiences)
            {
                _builder.AddWorkExperience(exp);
            }

            foreach (var edu in educations)
            {
                _builder.AddEducation(edu);
            }

            foreach (var skill in skills)
            {
                _builder.AddSkills(skill);
            }

            foreach (var project in projects)
            {
                _builder.AddProjects(project);
            }

            foreach (var reference in references)
            {
                _builder.AddReferences(reference);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // CV Cronologico
            var builder = new CVBuilderCronologico();
            var director = new GeneradorCV();
            director.SetBuilder(builder);

            director.ConstructCVCompleto(
                "John Doe, johndoe@example.com",
                new List<string> { "Software Engineer at XYZ", "Junior Developer at ABC" },
                new List<string> { "B.Sc. in Computer Science" },
                new List<string> { "C#", "SQL", "Python" },
                new List<string> { "Personal Website", "Mobile App" },
                new List<string> { "Jane Smith, Manager, XYZ" }
            );

            CV cv = builder.GetProduct();
            cv.DisplayConsole();

            Console.WriteLine("\n================================\n");

            // CV Funcional
            var functionalBuilder = new CVBuilderFuncional();
            director.SetBuilder(functionalBuilder);

            director.ConstructCVCompleto(
                "Jane Doe, janedoe@example.com",
                new List<string> { "Software Engineer at ABC" },  // Experiencia no usada en funcional
                new List<string> { "B.A. in Graphic Design" },
                new List<string> { "Adobe Photoshop", "Creative Direction" },
                new List<string> { "Art Website", "Design Portfolio" },
                new List<string> { "John Smith, Art Director, ABC" }
            );

            CV functionalCV = functionalBuilder.GetProduct();
            functionalCV.DisplayConsole();

            Console.WriteLine("\n================================\n");

            // CV Creativo
            var creativeBuilder = new CVBuilderCreativo();
            director.SetBuilder(creativeBuilder);

            director.ConstructCVCompleto(
                "Alice Johnson, alice@example.com",
                new List<string> { "Creative Director at XYZ" },
                new List<string> { "M.A. in Fine Arts" },
                new List<string> { "Graphic Design", "Painting" },
                new List<string> { "Art Exhibition", "Personal Art Blog" },
                new List<string> { "Paul Anderson, Art Collector" }
            );

            CV creativeCV = creativeBuilder.GetProduct();
            creativeCV.DisplayConsole();


            Console.ReadKey();
        }
    }
}
