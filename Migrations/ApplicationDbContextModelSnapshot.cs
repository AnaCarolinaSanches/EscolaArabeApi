﻿// <auto-generated />
using System;
using APIEscolaArabe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EscolaArabeApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("APIEscolaArabe.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("APIEscolaArabe.Models.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Dia")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("APIEscolaArabe.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("CEP")
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.Property<string>("Rua")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("APIEscolaArabe.Models.Modalidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DiasSemana")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("HorarioAula")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeCurso")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeProf")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Modalidades");
                });

            modelBuilder.Entity("EscolaArabeApi.Models.AlunoModalidade", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("ModalidadeId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "ModalidadeId");

                    b.HasIndex("ModalidadeId");

                    b.ToTable("AlunoModalidades");
                });

            modelBuilder.Entity("EscolaArabeApi.Models.ModalidadeAula", b =>
                {
                    b.Property<int>("AulaId")
                        .HasColumnType("int");

                    b.Property<int>("ModalidadeId")
                        .HasColumnType("int");

                    b.HasKey("AulaId", "ModalidadeId");

                    b.HasIndex("ModalidadeId");

                    b.ToTable("ModalidadeAula");
                });

            modelBuilder.Entity("APIEscolaArabe.Models.Aluno", b =>
                {
                    b.HasOne("APIEscolaArabe.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("EscolaArabeApi.Models.AlunoModalidade", b =>
                {
                    b.HasOne("APIEscolaArabe.Models.Aluno", "Aluno")
                        .WithMany("AlunosModalidades")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIEscolaArabe.Models.Modalidade", "modalidade")
                        .WithMany()
                        .HasForeignKey("ModalidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("modalidade");
                });

            modelBuilder.Entity("EscolaArabeApi.Models.ModalidadeAula", b =>
                {
                    b.HasOne("APIEscolaArabe.Models.Aula", "aula")
                        .WithMany()
                        .HasForeignKey("AulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIEscolaArabe.Models.Modalidade", "modalidade")
                        .WithMany("ModalidadeAulas")
                        .HasForeignKey("ModalidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aula");

                    b.Navigation("modalidade");
                });

            modelBuilder.Entity("APIEscolaArabe.Models.Aluno", b =>
                {
                    b.Navigation("AlunosModalidades");
                });

            modelBuilder.Entity("APIEscolaArabe.Models.Modalidade", b =>
                {
                    b.Navigation("ModalidadeAulas");
                });
#pragma warning restore 612, 618
        }
    }
}
