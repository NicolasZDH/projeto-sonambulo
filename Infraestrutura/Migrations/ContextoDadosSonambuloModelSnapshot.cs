﻿// <auto-generated />
using System;
using Infraestutura.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(ContextoDadosSonambulo))]
    partial class ContextoDadosSonambuloModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Dominio.Entidade.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR")
                        .HasDefaultValue("100")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("Pessoa", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidade.Sonho", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2024, 1, 27, 18, 23, 50, 862, DateTimeKind.Utc).AddTicks(2795))
                        .HasColumnName("criacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("descricao");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uuid")
                        .HasColumnName("pessoaId");

                    b.Property<DateTime?>("Realizacao")
                        .HasColumnType("DATETIME")
                        .HasColumnName("realizacao");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Sonho", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidade.Tarefa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativa")
                        .HasColumnType("BOOLEAN")
                        .HasColumnName("ativa");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("NCHARNCHAR")
                        .HasColumnName("Nome");

                    b.Property<int>("Periodicidade")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Periodicidade");

                    b.Property<int>("QuantidadePorPeriodo")
                        .HasColumnType("INT")
                        .HasColumnName("QuantidadePorPeriodo");

                    b.Property<Guid?>("SonhoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SonhoId");

                    b.ToTable("Tarefa", (string)null);
                });

            modelBuilder.Entity("Dominio.ObjetoDeValor.Feito", b =>
                {
                    b.Property<Guid>("TarefaId")
                        .HasColumnType("uuid")
                        .HasColumnName("idTarefa");

                    b.Property<DateTime>("Data")
                        .HasColumnType("DATE")
                        .HasColumnName("data");

                    b.Property<bool>("Concluido")
                        .HasColumnType("bool")
                        .HasColumnName("concluido");

                    b.HasKey("TarefaId", "Data");

                    b.ToTable("Feito", (string)null);
                });

            modelBuilder.Entity("Dominio.ObjetoDeValor.Recordacao", b =>
                {
                    b.Property<string>("Foto")
                        .HasColumnType("TEXT")
                        .HasColumnName("foto");

                    b.Property<DateTime>("Data")
                        .HasColumnType("DATE")
                        .HasColumnName("data");

                    b.Property<Guid?>("SonhoId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TarefaId")
                        .HasColumnType("uuid");

                    b.HasKey("Foto", "Data");

                    b.HasIndex("SonhoId");

                    b.HasIndex("TarefaId");

                    b.ToTable("Recordacao", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidade.Sonho", b =>
                {
                    b.HasOne("Dominio.Entidade.Pessoa", null)
                        .WithMany("Sonhos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pessoa_Sonho");
                });

            modelBuilder.Entity("Dominio.Entidade.Tarefa", b =>
                {
                    b.HasOne("Dominio.Entidade.Sonho", null)
                        .WithMany("Tarefas")
                        .HasForeignKey("SonhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Sonho_Tarefa");
                });

            modelBuilder.Entity("Dominio.ObjetoDeValor.Feito", b =>
                {
                    b.HasOne("Dominio.Entidade.Tarefa", null)
                        .WithMany("Feitos")
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tarefa_feito");
                });

            modelBuilder.Entity("Dominio.ObjetoDeValor.Recordacao", b =>
                {
                    b.HasOne("Dominio.Entidade.Sonho", null)
                        .WithMany("Recordacoes")
                        .HasForeignKey("SonhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Sonho_Recordacao");

                    b.HasOne("Dominio.Entidade.Tarefa", null)
                        .WithMany("Recordacoes")
                        .HasForeignKey("TarefaId");
                });

            modelBuilder.Entity("Dominio.Entidade.Pessoa", b =>
                {
                    b.Navigation("Sonhos");
                });

            modelBuilder.Entity("Dominio.Entidade.Sonho", b =>
                {
                    b.Navigation("Recordacoes");

                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("Dominio.Entidade.Tarefa", b =>
                {
                    b.Navigation("Feitos");

                    b.Navigation("Recordacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
