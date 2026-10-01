using System;
using System.Collections.Generic;
using System.Text;

namespace SRP__Patterns.DesignPatterns.src.PatternsLab.BuilderDesign
{
    /*
     
    Required:
   - StudentEmail
   - CourseCode
   - AccessMode

   Optional:
   - GroupCode
   - DiscountCode
   - MentorNote
   - PreferredStart

   Defaults:
   - SendWhatsApp
   - SendEmailWelcome
     */
    public class CourseRegistration
    {
        public string StudentEmail { get; }
        public string CourseCode { get; }
        public AccessMode AccessMode { get; }

        public string? GroupCode { get; }
        public string? DiscountCode { get; }
        public bool SendWhatsApp { get; }
        public bool SendEmailWelcome { get; }
        public string? MentorNote { get; }
        public DateOnly? PreferredStart { get; }

        public CourseRegistration(
            string studentEmail,
            string courseCode,
            AccessMode accessMode,
            string? groupCode,
            string? discountCode,
            bool sendWhatsApp,
            bool sendEmailWelcome,
            string? mentorNote,
            DateOnly? preferredStart)
        {
            StudentEmail = studentEmail;
            CourseCode = courseCode;
            AccessMode = accessMode;
            GroupCode = groupCode;
            DiscountCode = discountCode;
            SendWhatsApp = sendWhatsApp;
            SendEmailWelcome = sendEmailWelcome;
            MentorNote = mentorNote;
            PreferredStart = preferredStart;
        }
    }


    public class CourseRegistrationBuilder
    {
        // Required
        private string _studentEmail;
        private string _courseCode;
        private AccessMode _accessMode;

        // Optional
        private string? _groupCode;
        private string? _discountCode;
        private string? _mentorNote;
        private DateOnly? _preferredStart;

        // Default
        private bool _sendWhatsApp = false;
        private bool _sendEmailWelcome = false;


        // Required parameters
        public CourseRegistrationBuilder(
            string studentEmail,
            string courseCode,
            AccessMode accessMode)
        {
            _studentEmail = studentEmail;
            _courseCode = courseCode;
            _accessMode = accessMode;
        }


        // Optional parameters
        public CourseRegistrationBuilder GroupCode(string groupCode)
        {
            _groupCode = groupCode;
            return this;
        }

        public CourseRegistrationBuilder DiscountCode(string discountCode)
        {
            _discountCode = discountCode;
            return this;
        }

        public CourseRegistrationBuilder MentorNote(string mentorNote)
        {
            _mentorNote = mentorNote;
            return this;
        }

        public CourseRegistrationBuilder PreferredStart(DateOnly preferredStart)
        {
            _preferredStart = preferredStart;
            return this;
        }


        // Default values can be changed
        public CourseRegistrationBuilder SendWhatsApp(bool value)
        {
            _sendWhatsApp = value;
            return this;
        }

        public CourseRegistrationBuilder SendEmailWelcome(bool value)
        {
            _sendEmailWelcome = value;
            return this;
        }


        // Create the final object
        public CourseRegistration Build()
        {
            return new CourseRegistration(
                _studentEmail,
                _courseCode,
                _accessMode,
                _groupCode,
                _discountCode,
                _sendWhatsApp,
                _sendEmailWelcome,
                _mentorNote,
                _preferredStart
            );
        }
    }

}
