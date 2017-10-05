using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soding.Entities.Models
{
    /// <summary>
    /// Stores data for project table. Created by code first approach.
    /// </summary>
    public class Project : Entity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectStatus Status { get; set; }

        public string Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }

    /// <summary>Provides status for project row. </summary>
    public enum ProjectStatus
    {
        Active = 1,
        Delete = 2
    }
}
