using System;
//实现数据验证的类DataAnnotations
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MVC_Example.Models

{

    public class Movie

    {
        public int ID { get; set; }
        public string Title { get; set; }
        //Display属性指明要显示的字段的名称
        [Display(Name = "Release Date")]
        //DataType属性用于指定类型的数据
        [DataType(DataType.Date)]
        //DisplayFormat属性在Chrome浏览器里有一个bug：呈现的日期格式不正确
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

    }

    public class MovieDBContext : DbContext

    {

        public DbSet<Movie> Movies { get; set; }

    }

}