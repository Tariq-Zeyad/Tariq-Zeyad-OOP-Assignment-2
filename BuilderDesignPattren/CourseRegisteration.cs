using BuilderDesignPattren;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPattren
{
    public class CourseRegisteration
    {
        public string StudentName { get;  }
        public string CourseName { get;  }
        public DateTime StartDate { get;  }
        public bool IsOnline { get;  }
        public string ? CouponCode { get; }
        public decimal Fee { get; }
        public CourseRegisteration(string studentName, string courseName, DateTime startDate, bool isOnline, string? couponCode , decimal fee)
        {
            StudentName = studentName;
            CourseName = courseName;
            StartDate = startDate;
            IsOnline = isOnline;
            CouponCode = couponCode;
            Fee = fee;
        }

      
    
}
public class RegisterationBuilder
{
    // required values .
    // private fields 
    private readonly string _student;
    private readonly string _course;

    // Optional 
    private DateTime _date = DateTime.Today;
    private bool _isOnline;
    private string? _couponCode;
    private decimal _fee;

    public RegisterationBuilder(string student, string course)
    {
        _student = student;
        _course = course;

    }
    public RegisterationBuilder StartingOn(DateTime date)
    {
        _date = date;
        return this;
    }
    public RegisterationBuilder Online()
    {
        _isOnline = true;
        return this;

    }
    public RegisterationBuilder WithCupon(String code)
    {
        _couponCode = code;
        return this;
    }
    public RegisterationBuilder WithFee(decimal fee)
    {
        _fee = fee;
        return this;
    }
        public CourseRegisteration Build() =>
          new CourseRegisteration(
              _student,
              _course,
              _date,
              _isOnline,
              _couponCode,
              _fee
          ); 

    }
}