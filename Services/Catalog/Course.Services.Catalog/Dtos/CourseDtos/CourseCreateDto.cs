﻿using Course.Services.Catalog.Dtos.FeatureDtos;

namespace Course.Services.Catalog.Dtos.CourseDtos
{
    public class CourseCreateDto
    {
       

        public string Name { get; set; }

        public string Description { get; set; }


        public decimal Price { get; set; }
        public string UserId { get; set; }

        public decimal Picture{ get; set; }
        public FeatureDto Feature { get; set; }


        public string CategoryId { get; set; }


    }
}
