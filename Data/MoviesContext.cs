using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using MovieCorner.Models;

namespace MovieCorner.Data
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtistCategory> ArtistCategory { get; set; }
        public virtual DbSet<NameBasics> NameBasics { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<TitleAkas> TitleAkas { get; set; }
        public virtual DbSet<TitleBasics> TitleBasics { get; set; }
        public virtual DbSet<TitleEpisode> TitleEpisode { get; set; }
        public virtual DbSet<TitleGenre> TitleGenre { get; set; }
        public virtual DbSet<TitlePrincipals> TitlePrincipals { get; set; }
        public virtual DbSet<TitleRatings> TitleRatings { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserTitleRating> UserTitleRating { get; set; }
        public virtual DbSet<UserWatchlists> UserWatchlists { get; set; }
        public virtual DbSet<Watchlist> Watchlist { get; set; }
        public virtual DbSet<WatchlistTitles> WatchlistTitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistCategory>(entity =>
            {
                entity.HasKey(e => e.Category)
                    .HasName("PK__artist_c__F7F53CC394D51E7D");

                entity.ToTable("artist_category", "imdb");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NameBasics>(entity =>
            {
                entity.HasKey(e => e.Nconst)
                    .HasName("PK__name_bas__49B947A532DB7274");

                entity.ToTable("name_basics", "imdb");

                entity.Property(e => e.Nconst)
                    .HasColumnName("nconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BirthYear)
                    .IsRequired()
                    .HasColumnName("birthYear")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DeathYear)
                    .IsRequired()
                    .HasColumnName("deathYear")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.KnownForTitles)
                    .IsRequired()
                    .HasColumnName("knownForTitles")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryName)
                    .IsRequired()
                    .HasColumnName("primaryName")
                    .HasMaxLength(100);

                entity.Property(e => e.PrimaryProfession)
                    .HasColumnName("primaryProfession")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permission", "cms");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.PermissionName)
                    .IsRequired()
                    .HasColumnName("permissionName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TitleAkas>(entity =>
            {
                entity.HasKey(e => new { e.TitleId, e.Ordering })
                    .HasName("PK__title_ak__CAAA531D0063B476");

                entity.ToTable("title_akas", "imdb");

                entity.Property(e => e.TitleId)
                    .HasColumnName("titleId")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ordering)
                    .HasColumnName("ordering")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Attributes)
                    .IsRequired()
                    .HasColumnName("attributes")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsOriginalTitle)
                    .IsRequired()
                    .HasColumnName("isOriginalTitle")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnName("language")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Types)
                    .IsRequired()
                    .HasColumnName("types")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TitleNavigation)
                    .WithMany(p => p.TitleAkas)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_title_akas_title_basics");
            });

            modelBuilder.Entity<TitleBasics>(entity =>
            {
                entity.HasKey(e => e.Tconst)
                    .HasName("PK__title_ba__85FD534470056084");

                entity.ToTable("title_basics", "imdb");

                entity.Property(e => e.Tconst)
                    .HasColumnName("tconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EndYear)
                    .IsRequired()
                    .HasColumnName("endYear")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Genres)
                    .HasColumnName("genres")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdult)
                    .IsRequired()
                    .HasColumnName("isAdult")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OriginalTitle)
                    .HasColumnName("originalTitle")
                    .HasMaxLength(255);

                entity.Property(e => e.PrimaryTitle)
                    .IsRequired()
                    .HasColumnName("primaryTitle")
                    .HasMaxLength(255);

                entity.Property(e => e.RuntimeMinutes)
                    .IsRequired()
                    .HasColumnName("runtimeMinutes")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StartYear)
                    .IsRequired()
                    .HasColumnName("startYear")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TitleType)
                    .IsRequired()
                    .HasColumnName("titleType")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TitleEpisode>(entity =>
            {
                entity.HasKey(e => e.Tconst)
                    .HasName("PK__title_ep__85FD5344D7184936");

                entity.ToTable("title_episode", "imdb");

                entity.Property(e => e.Tconst)
                    .HasColumnName("tconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EpisodeNumber)
                    .IsRequired()
                    .HasColumnName("episodeNumber")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ParentTconst)
                    .IsRequired()
                    .HasColumnName("parentTconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SeasonNumber)
                    .IsRequired()
                    .HasColumnName("seasonNumber")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TitleGenre>(entity =>
            {
                entity.HasKey(e => new { e.Genre, e.Tconst })
                    .HasName("PK__title_ge__DE3F75FDE67FA8FD");

                entity.ToTable("title_genre", "imdb");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tconst)
                    .HasColumnName("tconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany(p => p.TitleGenre)
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_title_genre_title_basics");
            });

            modelBuilder.Entity<TitlePrincipals>(entity =>
            {
                entity.HasKey(e => new { e.Tconst, e.Ordering })
                    .HasName("PK__title_pr__0225D6D320B8300E");

                entity.ToTable("title_principals", "imdb");

                entity.Property(e => e.Tconst)
                    .HasColumnName("tconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ordering)
                    .HasColumnName("ordering")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Characters)
                    .IsRequired()
                    .HasColumnName("characters")
                    .HasMaxLength(255);

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasColumnName("job")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nconst)
                    .IsRequired()
                    .HasColumnName("nconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.TitlePrincipals)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_title_principals_artist_category");

                entity.HasOne(d => d.NconstNavigation)
                    .WithMany(p => p.TitlePrincipals)
                    .HasForeignKey(d => d.Nconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_title_principals_name_basics");

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany(p => p.TitlePrincipals)
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_title_principals_title_basics");
            });

            modelBuilder.Entity<TitleRatings>(entity =>
            {
                entity.HasKey(e => e.Tconst)
                    .HasName("PK__title_ra__85FD5344C98B1288");

                entity.ToTable("title_ratings", "imdb");

                entity.Property(e => e.Tconst)
                    .HasColumnName("tconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AverageRating)
                    .IsRequired()
                    .HasColumnName("averageRating")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumVotes)
                    .IsRequired()
                    .HasColumnName("numVotes")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "cms");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("fullName")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UserTitleRating>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Tconst })
                    .HasName("PK_user_titlerating");

                entity.ToTable("user_title_rating", "cms");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Tconst)
                    .HasColumnName("tconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany(p => p.UserTitleRating)
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_titlerating_title_basics");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTitleRating)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_titlerating_user");
            });

            modelBuilder.Entity<UserWatchlists>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.WatchlistId });

                entity.ToTable("user_watchlists", "cms");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.WatchlistId).HasColumnName("watchlistId");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserWatchlists)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_watchlists_permission");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserWatchlists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_watchlists_user");

                entity.HasOne(d => d.Watchlist)
                    .WithMany(p => p.UserWatchlists)
                    .HasForeignKey(d => d.WatchlistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_watchlists_watchlist");
            });

            modelBuilder.Entity<Watchlist>(entity =>
            {
                entity.ToTable("watchlist", "cms");

                entity.Property(e => e.WatchlistId)
                    .HasColumnName("watchlistId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WatchlistTitles>(entity =>
            {
                entity.HasKey(e => new { e.WatchlistId, e.Tconst });

                entity.ToTable("watchlist_titles", "cms");

                entity.Property(e => e.WatchlistId).HasColumnName("watchlistId");

                entity.Property(e => e.Tconst)
                    .HasColumnName("tconst")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SequenceNum).HasColumnName("sequenceNum");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.TconstNavigation)
                    .WithMany(p => p.WatchlistTitles)
                    .HasForeignKey(d => d.Tconst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_watchlist_titles_title_basics");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WatchlistTitles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_watchlist_titles_user");

                entity.HasOne(d => d.Watchlist)
                    .WithMany(p => p.WatchlistTitles)
                    .HasForeignKey(d => d.WatchlistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_watchlist_titles_watchlist");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
