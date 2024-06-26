USE SmartSalon

CREATE TABLE Bookings(
    Id uniqueidentifier NOT NULL,
    Date date NOT NULL,
    From time(7) NOT NULL,
    To time(7) NOT NULL,
    ServiceId uniqueidentifier NOT NULL,
    CustomerId uniqueidentifier NOT NULL,
    SalonId uniqueidentifier NOT NULL,
    WorkerId uniqueidentifier NOT NULL,
    DeletedOn datetimeoffset(7) NULL,
    DeletedBy uniqueidentifier NULL,
    IsDeleted bit NOT NULL,
    CONSTRAINT PK_Bookings PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_Bookings_Salons_SalonId FOREIGN KEY (SalonId) REFERENCES Salons(Id),
    CONSTRAINT FK_Bookings_Services_ServiceId FOREIGN KEY (ServiceId) REFERENCES Services(Id),
    CONSTRAINT FK_Bookings_Users_CustomerId FOREIGN KEY (CustomerId) REFERENCES Users(Id),
    CONSTRAINT FK_Bookings_Users_WorkerId FOREIGN KEY (WorkerId) REFERENCES Users(Id)
);

CREATE TABLE Categories(
    Id uniqueidentifier NOT NULL,
    Name nvarchar(max) NOT NULL,
    SalonId uniqueidentifier NOT NULL,
    SectionId uniqueidentifier NULL,
    CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_Categories_Salons_SalonId FOREIGN KEY (SalonId) REFERENCES Salons(Id),
    CONSTRAINT FK_Categories_Sections_SectionId FOREIGN KEY (SectionId) REFERENCES Sections(Id)
);

CREATE TABLE Currencies(
    Id uniqueidentifier NOT NULL,
    Code nvarchar(3) NOT NULL,
    Name nvarchar(50) NOT NULL,
    Country nvarchar(50) NOT NULL,
    CONSTRAINT PK_Currencies PRIMARY KEY CLUSTERED (Id ASC)
);

CREATE TABLE CustomerSubscription(
    ActiveCustomersId uniqueidentifier NOT NULL,
    SubscriptionsId uniqueidentifier NOT NULL,
    CONSTRAINT PK_CustomerSubscription PRIMARY KEY CLUSTERED ( ActiveCustomersId ASC, SubscriptionsId ASC),
    CONSTRAINT FK_CustomerSubscription_Users_ActiveCustomersId FOREIGN KEY (ActiveCustomersId) REFERENCES Users(Id),
    CONSTRAINT FK_CustomerSubscription_Subscriptions_SubscriptionsId FOREIGN KEY (SubscriptionsId) REFERENCES Subscriptions(Id)
);

CREATE TABLE Logins(
    LoginProvider nvarchar(450) NOT NULL,
    ProviderKey nvarchar(450) NOT NULL,
    ProviderDisplayName nvarchar(max) NULL,
    UserId uniqueidentifier NOT NULL,
    CONSTRAINT PK_Logins PRIMARY KEY CLUSTERED (LoginProvider ASC, ProviderKey ASC),
    CONSTRAINT FK_Logins_Users_UserId FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE OwnerSalon(
    OwnersId uniqueidentifier NOT NULL,
    SalonsId uniqueidentifier NOT NULL,
    CONSTRAINT PK_OwnerSalon PRIMARY KEY CLUSTERED ( OwnersId ASC, SalonsId ASC),
    CONSTRAINT FK_OwnerSalon_Users_OwnersId FOREIGN KEY (OwnersId) REFERENCES Users(Id),
    CONSTRAINT FK_OwnerSalon_Salons_SalonsId FOREIGN KEY (SalonsId) REFERENCES Salons(Id)
);

CREATE TABLE Roles(
    Id uniqueidentifier NOT NULL,
    Name nvarchar(50) NOT NULL,
    NormalizedName nvarchar(50) NOT NULL,
    ConcurrencyStamp nvarchar(max) NULL,
    CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED (Id ASC)
);

CREATE TABLE SalonImages(
    Id uniqueidentifier NOT NULL,
    Url nvarchar(200) NOT NULL,
    SalonId uniqueidentifier NOT NULL,
    CONSTRAINT PK_SalonImages PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_SalonImages_Salons_SalonId FOREIGN KEY (SalonId) REFERENCES Salons(Id)
);

CREATE TABLE Salons(
    Id uniqueidentifier NOT NULL,
    Name nvarchar(50) NOT NULL,
    Description nvarchar(50) NOT NULL,
    Location nvarchar(50) NOT NULL,
    ProfilePictureUrl nvarchar(max) NULL,
    DefaultTimePenalty int NOT NULL,
    DefaultBookingsInAdvance int NOT NULL,
    SubscriptionsEnabled bit NOT NULL CONSTRAINT DF_Salons_SubscriptionsEnabled DEFAULT (1),
    SectionsEnabled bit NOT NULL,
    WorkersCanMoveBookings bit NOT NULL CONSTRAINT DF_Salons_WorkersCanMoveBookings DEFAULT (1),
    WorkersCanSetNonWorkingPeriods bit NOT NULL CONSTRAINT DF_Salons_WorkersCanSetNonWorkingPeriods DEFAULT (1),
    WorkingTimeId uniqueidentifier NULL,
    CurrencyId uniqueidentifier NULL,
    CONSTRAINT PK_Salons PRIMARY KEY CLUSTERED ( Id ASC),
    CONSTRAINT FK_Salons_Currencies_CurrencyId FOREIGN KEY (CurrencyId) REFERENCES Currencies(Id)
);

CREATE TABLE SalonSpecialties(
    Id uniqueidentifier NOT NULL,
    Text nvarchar(200) NOT NULL,
    SalonId uniqueidentifier NOT NULL,
    CONSTRAINT PK_SalonSpecialties PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_SalonSpecialties_Salons_SalonId FOREIGN KEY (SalonId) REFERENCES Salons(Id)
 );

CREATE TABLE Sections(
    Id uniqueidentifier NOT NULL,
    Name nvarchar(max) NOT NULL,
    SalonId uniqueidentifier NOT NULL,
    CONSTRAINT PK_Sections PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_Sections_Salons_SalonId FOREIGN KEY (SalonId) REFERENCES Salons(Id)
 ); 

CREATE TABLE Services(
    Id uniqueidentifier NOT NULL,
    Name nvarchar(50) NOT NULL,
    Description nvarchar(50) NOT NULL,
    Price float NOT NULL,
    DurationInMinutes int NOT NULL,
    SalonId uniqueidentifier NOT NULL,
    CategoryId uniqueidentifier NOT NULL,
    CategorieId uniqueidentifier NULL,
    SubscriptionId uniqueidentifier NULL,
    CONSTRAINT PK_Services PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_Services_Salons_SalonId FOREIGN KEY (SalonId) REFERENCES Salons(Id),
    CONSTRAINT FK_Services_Categories_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    CONSTRAINT FK_Services_Subscriptions_SubscriptionId FOREIGN KEY (SubscriptionId) REFERENCES Subscriptions(Id)
 ); 

CREATE TABLE SpecialSlots(
    Id uniqueidentifier NOT NULL,
    From time(7) NOT NULL,
    To time(7) NOT NULL,
    DayOfWeek int NOT NULL,
    ExpirationInDays int NOT NULL,
    ServiceId uniqueidentifier NOT NULL,
    SubscriptionId uniqueidentifier NULL,
    CONSTRAINT PK_SpecialSlots PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_SpecialSlots_Services_ServiceId FOREIGN KEY (ServiceId) REFERENCES Services(Id),
    CONSTRAINT FK_SpecialSlots_Subscriptions_SubscriptionId FOREIGN KEY (SubscriptionId) REFERENCES Subscriptions(Id)
);

CREATE TABLE Subscriptions(
    Id uniqueidentifier NOT NULL,
    TimePenaltyInDays int NOT NULL,
    AllowedBookingsInAdvance int NOT NULL,
    Tier int NOT NULL,
    Duration int NOT NULL,
    SalonId uniqueidentifier NOT NULL,
    CONSTRAINT PK_Subscriptions PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_Subscriptions_Salons_SalonId FOREIGN KEY (SalonId) REFERENCES Salons(Id)
 );

CREATE TABLE UserRole(
    UserId uniqueidentifier NOT NULL,
    RoleId uniqueidentifier NOT NULL,
    CONSTRAINT PK_UserRole PRIMARY KEY CLUSTERED (UserId ASC,    RoleId ASC),
    CONSTRAINT FK_UserRole_Users_UserId FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_UserRole_Roles_RoleId FOREIGN KEY (RoleId) REFERENCES Roles(Id)
)

CREATE TABLE Users(
    Id uniqueidentifier NOT NULL,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    ProfilePictureUrl nvarchar(max) NULL,
    UserType nvarchar(8) NOT NULL,
    IsDeleted bit NOT NULL,
    DeletedOn datetimeoffset(7) NULL,
    DeletedBy uniqueidentifier NULL,
    Email nvarchar(50) NOT NULL,
    PhoneNumber nvarchar(50) NOT NULL,
    UserName nvarchar(50) NOT NULL,
    SalonId uniqueidentifier NULL,
    JobTitle nvarchar(50) NULL,
    Nickname nvarchar(50) NULL,
    NormalizedUserName nvarchar(50) NOT NULL,
    NormalizedEmail nvarchar(256) NULL,
    EmailConfirmed bit NOT NULL,
    PasswordHash nvarchar(max) NULL,
    SecurityStamp nvarchar(max) NOT NULL,
    ConcurrencyStamp nvarchar(max) NOT NULL,
    PhoneNumberConfirmed bit NOT NULL,
    TwoFactorEnabled bit NOT NULL,
    LockoutEnd datetimeoffset(7) NULL,
    LockoutEnabled bit NOT NULL,
    AccessFailedCount int NOT NULL,
    CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_Users_Salons_SalonId FOREIGN KEY (SalonId) REFERENCES Salons(Id)
);

CREATE TABLE WorkingTimes(
    Id uniqueidentifier NOT NULL,
    SalonId uniqueidentifier NOT NULL,
    MondayFrom time(7) NOT NULL,
    MondayTo time(7) NOT NULL,
    TuesdayFrom time(7) NOT NULL,
    TuesdayTo time(7) NOT NULL,
    WednesdayFrom time(7) NOT NULL,
    WednesdayTo time(7) NOT NULL,
    ThursdayFrom time(7) NOT NULL,
    ThursdayTo time(7) NOT NULL,
    FridayFrom time(7) NOT NULL,
    FridayTo time(7) NOT NULL,
    SaturdayFrom time(7) NOT NULL,
    SaturdayTo time(7) NOT NULL,
    SundayFrom time(7) NOT NULL,
    SundayTo time(7) NOT NULL,
    CONSTRAINT PK_WorkingTimes PRIMARY KEY CLUSTERED(Id ASC),
    CONSTRAINT FK_WorkingTimes_Salons_SalonId FOREIGN KEY (SalonId) REFERENCES Salons(Id)
);
