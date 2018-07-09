﻿using RestWithAspNETUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Data model representation
/// </summary>
namespace RestWithAspNETUdemy.Model
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public GenderEnum Gender { get; set; }
    }

    public enum GenderEnum
    {
        Male,
        Female
    }
}
