using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HolidayCottageManager.Shared.Services;

namespace HolidayCottageManager.Shared.Migrations
{
    [DbContext(typeof(DatabaseService))]
    partial class DatabaseServiceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("HolidayCottageManager.Shared.Locomotive", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Adress");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("PartNumber");

                    b.Property<string>("ProductLink");

                    b.HasKey("id");

                    b.ToTable("Locomotives");
                });

            modelBuilder.Entity("HolidayCottageManager.Shared.Models.Wagon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("PartNumber");

                    b.Property<string>("ProductLink");

                    b.HasKey("id");

                    b.ToTable("Wagons");
                });

            modelBuilder.Entity("HolidayCottageManager.Shared.Track", b =>
                {
                    b.Property<int>("PartNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.HasKey("PartNumber");

                    b.ToTable("Tracks");
                });
        }
    }
}
