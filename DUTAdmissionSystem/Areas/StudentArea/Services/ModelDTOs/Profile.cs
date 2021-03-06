﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs
{
    public class Profile
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Avatar { get; set; }

        public bool Sex { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        public int NationalityId { get; set; }

        public int ReligionId { get; set; }

        public int EthnicId { get; set; }

        public string IdentityNumber { get; set; }

        public DateTime? DateOfIssue { get; set; }

        public string PlaceOfIssue { get; set; }

        public int CircumstanceTypeId { get; set; }

        public string PermanentResidence { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string HighSchoolName { get; set; }

        public bool IsJoinYouthGroup { get; set; }

        public DateTime DateOfJoiningYouthGroup { get; set; }

        public string PlaceOfJoinYouthGroup { get; set; }

        public bool HavingBooksOfYouthGroup { get; set; }

        public bool HavingCardsOfYouthGroup { get; set; }

        public string ClassName { get; set; }
        public string DepartmentName { get; set; }
        public string FacultyName { get; set; }
        public string ProgramName { get; set; }
        public string EnrollmentAreaName { get; set; }
        public string ElectionName { get; set; }

        public List<FamilyMember> FamilyMembers { get; set; }
        public List<HighSchoolResult> HighSchoolResults { get; set; }
        public List<Achievement> Achievements { get; set; }

    }

    public class Avatar
    {
        public string Name { get; set; }
        public string File { get; set; }
    }


}