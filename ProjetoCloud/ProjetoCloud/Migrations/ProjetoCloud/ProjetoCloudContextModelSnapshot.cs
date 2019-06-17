﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoCloud.Models;

namespace ProjetoCloud.Migrations.ProjetoCloud
{
    [DbContext(typeof(ProjetoCloudContext))]
    partial class ProjetoCloudContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProjetoCloud.Areas.Identity.Data.ProjetoCloudUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("UsuarioDeAplicacaoId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UsuarioDeAplicacaoId")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Ambiente", b =>
                {
                    b.Property<int>("Id_Ambiente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_Cadastro_Ambiente");

                    b.Property<string>("Nome_Ambiente");

                    b.Property<int>("Qtda_Dispositivo_Ambiente");

                    b.Property<int?>("UsuarioId_Usuario");

                    b.HasKey("Id_Ambiente");

                    b.HasIndex("UsuarioId_Usuario");

                    b.ToTable("Ambiente");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Dispositivo", b =>
                {
                    b.Property<int>("Id_Dispositivo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmbienteId_Ambiente");

                    b.Property<DateTime>("Data_Cadastro_Dispositivo");

                    b.Property<string>("Nome_Dispositivo");

                    b.Property<bool>("Status_Dispositivo");

                    b.HasKey("Id_Dispositivo");

                    b.HasIndex("AmbienteId_Ambiente");

                    b.ToTable("Dispositivo");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Plano", b =>
                {
                    b.Property<int>("Id_Plano")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_Cadastro_Plano");

                    b.Property<string>("Nome_Plano");

                    b.Property<int>("Qtde_Max_Dispositivos_Plano");

                    b.Property<decimal>("Valor_Plano");

                    b.HasKey("Id_Plano");

                    b.ToTable("Plano");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Usuario", b =>
                {
                    b.Property<int>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Adm_Usuario");

                    b.Property<string>("CEP_Usuario");

                    b.Property<string>("CPF_Usuario");

                    b.Property<string>("Cartao_Usuario");

                    b.Property<DateTime>("Data_Cadastro_Usuario");

                    b.Property<string>("Nome_Usuario");

                    b.Property<int?>("Plano_UsuarioId_Plano");

                    b.Property<int>("UsuarioDeAutenticacaoId");

                    b.HasKey("Id_Usuario");

                    b.HasIndex("Plano_UsuarioId_Plano");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProjetoCloud.Areas.Identity.Data.ProjetoCloudUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProjetoCloud.Areas.Identity.Data.ProjetoCloudUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoCloud.Areas.Identity.Data.ProjetoCloudUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProjetoCloud.Areas.Identity.Data.ProjetoCloudUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoCloud.Areas.Identity.Data.ProjetoCloudUser", b =>
                {
                    b.HasOne("ProjetoCloud.Models.Usuario", "UsuarioDeAplicacao")
                        .WithOne("UsuarioDeAutenticacao")
                        .HasForeignKey("ProjetoCloud.Areas.Identity.Data.ProjetoCloudUser", "UsuarioDeAplicacaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoCloud.Models.Ambiente", b =>
                {
                    b.HasOne("ProjetoCloud.Models.Usuario")
                        .WithMany("Ambientes_Usuario")
                        .HasForeignKey("UsuarioId_Usuario");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Dispositivo", b =>
                {
                    b.HasOne("ProjetoCloud.Models.Ambiente")
                        .WithMany("Dispositivos_Ambiente")
                        .HasForeignKey("AmbienteId_Ambiente");
                });

            modelBuilder.Entity("ProjetoCloud.Models.Usuario", b =>
                {
                    b.HasOne("ProjetoCloud.Models.Plano", "Plano_Usuario")
                        .WithMany()
                        .HasForeignKey("Plano_UsuarioId_Plano");
                });
#pragma warning restore 612, 618
        }
    }
}
