﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GearOptimizer.Model;

namespace GearOptimizer.Migrations
{
    [DbContext(typeof(GearOptimizerDbContext))]
    partial class GearOptimizerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GearOptimizer.Model.Boss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AtkStyle");

                    b.Property<string>("Name");

                    b.Property<string>("Weakness");

                    b.HasKey("Id");

                    b.ToTable("Bosses");
                });

            modelBuilder.Entity("GearOptimizer.Model.BossDrops", b =>
                {
                    b.Property<int>("BossId");

                    b.Property<int>("DropId");

                    b.HasKey("BossId", "DropId");

                    b.HasIndex("BossId");

                    b.HasIndex("DropId");

                    b.ToTable("BossDrops");
                });

            modelBuilder.Entity("GearOptimizer.Model.Drop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Drops");
                });

            modelBuilder.Entity("GearOptimizer.Model.FullSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArrowSlotId");

                    b.Property<int>("BootsId");

                    b.Property<int>("BossId");

                    b.Property<int>("CapeId");

                    b.Property<int>("ChestSlotId");

                    b.Property<int>("FullSetId");

                    b.Property<int?>("GearId");

                    b.Property<int>("GlovesId");

                    b.Property<int>("HeadSlotId");

                    b.Property<int>("LegSlotId");

                    b.Property<int>("MainHandId");

                    b.Property<int>("NecklaceId");

                    b.Property<int>("OffHandId");

                    b.Property<int>("RingId");

                    b.Property<string>("SetName");

                    b.HasKey("Id");

                    b.HasIndex("BossId");

                    b.HasIndex("GearId");

                    b.ToTable("FullSets");
                });

            modelBuilder.Entity("GearOptimizer.Model.Gear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AtkCrush");

                    b.Property<int>("AtkMagic");

                    b.Property<int>("AtkRange");

                    b.Property<int>("AtkSlash");

                    b.Property<int>("AtkStab");

                    b.Property<int>("DefCrush");

                    b.Property<int>("DefMagic");

                    b.Property<int>("DefRange");

                    b.Property<int>("DefSlash");

                    b.Property<int>("DefStab");

                    b.Property<int>("MagicDmg");

                    b.Property<int>("MeleeStr");

                    b.Property<string>("Name");

                    b.Property<int>("Prayer");

                    b.Property<int>("Price");

                    b.Property<int>("RangeStr");

                    b.Property<string>("Reqs");

                    b.Property<int>("Slayer");

                    b.Property<string>("Slot");

                    b.Property<int>("Undead");

                    b.HasKey("Id");

                    b.ToTable("Gears");
                });

            modelBuilder.Entity("GearOptimizer.Model.BossDrops", b =>
                {
                    b.HasOne("GearOptimizer.Model.Boss", "Boss")
                        .WithMany("BossDrops")
                        .HasForeignKey("BossId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GearOptimizer.Model.Drop", "Drop")
                        .WithMany("BossDrops")
                        .HasForeignKey("DropId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GearOptimizer.Model.FullSet", b =>
                {
                    b.HasOne("GearOptimizer.Model.Boss", "Boss")
                        .WithMany("FullSets")
                        .HasForeignKey("BossId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GearOptimizer.Model.Gear")
                        .WithMany("FullSets")
                        .HasForeignKey("GearId");
                });
        }
    }
}
