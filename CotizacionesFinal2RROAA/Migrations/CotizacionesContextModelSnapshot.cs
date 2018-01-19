﻿// <auto-generated />
using Cotizaciones.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Cotizaciones.Migrations
{
    [DbContext(typeof(CotizacionesContext))]
    partial class CotizacionesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Cotizaciones.Models.Cotizacion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PersonaRut");

                    b.Property<string>("descripcionCotizacion");

                    b.Property<string>("estadoCotizacion");

                    b.Property<DateTime>("fechaCotizacion");

                    b.Property<DateTime>("fechaValidez");

                    b.Property<string>("nombreCliente");

                    b.Property<int>("valorCotizacion");

                    b.HasKey("ID");

                    b.HasIndex("PersonaRut");

                    b.ToTable("Cotizacion");
                });

            modelBuilder.Entity("Cotizaciones.Models.Persona", b =>
                {
                    b.Property<string>("Rut")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Materno");

                    b.Property<string>("Nombre");

                    b.Property<string>("Paterno");

                    b.HasKey("Rut");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Cotizaciones.Models.Cotizacion", b =>
                {
                    b.HasOne("Cotizaciones.Models.Persona", "persona")
                        .WithMany()
                        .HasForeignKey("PersonaRut");
                });
#pragma warning restore 612, 618
        }
    }
}