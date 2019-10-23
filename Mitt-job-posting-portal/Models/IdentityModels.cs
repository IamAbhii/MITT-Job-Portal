﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mitt_job_posting_portal.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class Student
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int CourseId { get; set; }
        public Course CorseName { get; set; }

    }
    public class Employer
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string CompanyName { get; set; }
        public string EmailAdress { get; set; }
        public virtual ICollection<JobPost> JobPosts { get; set; }

    } 

    public class Instructor
    {   
        [Key,ForeignKey("User")]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public virtual User User { get; set; }
        public ICollection<CourseInstructor> Courses { get; set; }

    }

    public class CourseInstructor
    {
        [Key,Column(Order=0)]
        public string InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        [Key, Column(Order = 1)]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

    }

    public class JobApplication
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Skills { get; set; }
        public virtual ICollection<User> Students { get; set; }
        public int JobPostId { get; set; }
        public virtual JobPost JobPosts { get; set; }
    }

    public class JobPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public int RoundId { get; set; }
        public virtual Round Rounds { get; set; }
        public int EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
    }

    public class Round
    {
        public int Id { get; set; }
        public DateTime InternshipEndtDate { get; set; }
        public DateTime InternshipStartDate { get; set; }
        public virtual ICollection<JobPost> JobPosts { get; set; }

    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InternshipStartDate { get; set; }
        public DateTime InternshipEndDate { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndeDate { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<CourseInstructor> Instructors { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<JobPost> JobPost { get; set; }
        public DbSet<JobApplication> JobApplication { get; set; }
        public DbSet<CourseInstructor> CourseInstructor { get; set; }
        public DbSet<Round> Round { get; set; }
        public DbSet<Course> Course { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}