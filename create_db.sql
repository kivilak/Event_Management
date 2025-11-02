CREATE DATABASE "Event-Management";

CREATE TABLE events (
    event_id INT PRIMARY KEY IDENTITY(1,1),
    event_name VARCHAR(255) NOT NULL,
    event_type VARCHAR(100) NOT NULL,
    category VARCHAR(100),
    tags TEXT,
    description TEXT,
    event_date DATE NOT NULL,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    venue_name VARCHAR(255) NOT NULL,
    street_address VARCHAR(255) NOT NULL,
    city VARCHAR(100) NOT NULL,
    state_province VARCHAR(100) NOT NULL,
    maximum_capacity INT NOT NULL DEFAULT 0,
    current_registrations INT NOT NULL DEFAULT 0,
    email VARCHAR(50) NOT NULL,
    event_web VARCHAR(100),
    phone_number BIGINT,
    is_free_event BIT DEFAULT 0,
    regular_price DECIMAL(10, 2) DEFAULT 0.00,
    early_bird_price DECIMAL(10, 2) DEFAULT 0.00,
    vip_price DECIMAL(10, 2) DEFAULT 0.00,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    status VARCHAR(20) DEFAULT 'draft' CHECK (status IN ('draft', 'published', 'cancelled', 'completed'))
);

INSERT INTO events (
    event_name, 
    event_type, 
    category, 
    tags, 
    description, 
    event_date, 
    start_time, 
    end_time, 
    venue_name, 
    street_address, 
    city, 
    state_province, 
    maximum_capacity, 
    current_registrations, 
    email, 
    event_web, 
    phone_number, 
    is_free_event, 
    regular_price, 
    early_bird_price, 
    vip_price, 
    status
) VALUES 
(
    'Tech Innovation Summit 2025',
    'Conference',
    'Technology',
    'AI, Machine Learning, Innovation, Networking',
    'Join industry leaders and innovators for a full-day conference exploring the latest trends in artificial intelligence, machine learning, and digital transformation.',
    '2025-11-15',
    '09:00:00',
    '18:00:00',
    'Grand Plaza Convention Center',
    '123 Innovation Drive',
    'San Francisco',
    'California',
    500,
    287,
    'info@techinnovation.com',
    'www.techinnovationsummit.com',
    4155551234,
    0,
    299.00,
    199.00,
    499.00,
    'published'
),
(
    'Community Yoga in the Park',
    'Workshop',
    'Health & Wellness',
    'Yoga, Fitness, Outdoor, Wellness',
    'Free outdoor yoga session for all skill levels. Bring your own mat and enjoy a peaceful morning practice in beautiful surroundings.',
    '2025-11-02',
    '07:00:00',
    '08:30:00',
    'Sunset Park',
    '456 Park Avenue',
    'Portland',
    'Oregon',
    50,
    32,
    'hello@communityyoga.org',
    'www.communityyogapdx.org',
    5035559876,
    1,
    0.00,
    0.00,
    0.00,
    'published'
),
(
    'Jazz Under the Stars Festival',
    'Festival',
    'Music & Entertainment',
    'Jazz, Live Music, Festival, Outdoor',
    'An enchanting evening featuring renowned jazz musicians from around the world. Food vendors and craft beverages available.',
    '2025-12-08',
    '18:00:00',
    '23:00:00',
    'Riverside Amphitheater',
    '789 Waterfront Boulevard',
    'Austin',
    'Texas',
    2000,
    1456,
    'tickets@jazzstars.com',
    'www.jazzunderthestars.com',
    5125554567,
    0,
    75.00,
    55.00,
    150.00,
    'published'
),
(
    'Startup Pitch Competition',
    'Competition',
    'Business & Entrepreneurship',
    'Startups, Pitching, Venture Capital, Networking',
    'Watch emerging startups pitch their innovative ideas to a panel of investors. Winner receives $50,000 in seed funding.',
    '2025-11-20',
    '14:00:00',
    '19:00:00',
    'Innovation Hub',
    '321 Entrepreneur Street',
    'Boston',
    'Massachusetts',
    200,
    0,
    'contact@startuppitch.com',
    'www.startuppitchboston.com',
    6175552345,
    0,
    50.00,
    35.00,
    100.00,
    'draft'
),
(
    'Holiday Artisan Market',
    'Market',
    'Arts & Crafts',
    'Handmade, Shopping, Local Artists, Holiday',
    'Shop unique handcrafted gifts from over 100 local artisans. Perfect for finding one-of-a-kind holiday presents while supporting local creators.',
    '2025-12-14',
    '10:00:00',
    '17:00:00',
    'City Center Exhibition Hall',
    '555 Main Street',
    'Seattle',
    'Washington',
    1000,
    0,
    'info@artisanmarket.com',
    'www.holidayartisanmarket.com',
    2065558901,
    1,
    0.00,
    0.00,
    0.00,
    'published'
);

DROP TABLE IF EXISTS Guest;

CREATE TABLE Guest(
	GuestId int IDENTITY(1, 1),
	Name VARCHAR(50), 
	Email VARCHAR(50),
	Phone VARCHAR(15),
	Category VARCHAR(20),
	RsvpStatus VARCHAR(10),
	Dietary VARCHAR(20),
	CheckedIn BIT,
	EventId INT
);

INSERT INTO Guest(Name, Email, Phone, Category, RsvpStatus, Dietary, CheckedIn, EventId)
VALUES
('Alice Johnson', 'alice.johnson@example.com', '123-456-7890', 'Speaker', 'Confirmed', 'Vegetarian', 1, 1),
('Bob Smith', 'bob.smith@example.com', '987-654-3210', 'Attendee', 'Pending', 'None', 0, 1),
('Carol Lee', 'carol.lee@example.com', '555-123-4567', 'Attendee', 'Declined', 'Gluten-Free', 0, 2),
('David Kim', 'david.kim@example.com', '444-321-9876', 'Speaker', 'Confirmed', 'Vegan', 1, 3),
('Emily Davis', 'emily.davis@example.com', '111-222-3333', 'Attendee', 'Confirmed', 'None', 0, 3);

DROP TABLE IF EXISTS Budget;

CREATE TABLE Budget(
	BudgetId int IDENTITY(1, 1),
	Category VARCHAR(50),
	Estimated FLOAT,
	Actual FLOAT,
	EventId int
);

INSERT INTO Budget(Category, Estimated, Actual, EventId)
VALUES 
('Venue', 15000, 14500, 1),
('Catering', 8000, 8500, 1),
('Venue', 15000, 14500, 1),
('Transportation', 2000, 1650, 1);

CREATE TABLE Task (
    TaskId INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Priority VARCHAR(50),
    Description TEXT,
    Category VARCHAR(100),
    Status VARCHAR(50),
    CheckedIn BIT DEFAULT 0,
    EventId INT,
    CONSTRAINT FK_Task_Event FOREIGN KEY (EventId) REFERENCES events(event_id)
);

INSERT INTO Task (Title, Priority, Description, Category, Status, CheckedIn, EventId)
VALUES
('Book venue', 'High', 'Reserve the main hall for the conference', 'Venue', 'Completed', 1, 1),
('Send invitations', 'High', 'Email invitations to all guests', 'Communication', 'Completed', 1, 1),
('Arrange catering', 'Medium', 'Contact catering service for lunch and snacks', 'Food & Beverage', 'In Progress', 0, 1),
('Setup AV equipment', 'High', 'Test projector, microphones, and speakers', 'Technical', 'Pending', 0, 1),
('Print name badges', 'Low', 'Design and print badges for all attendees', 'Admin', 'Pending', 0, 1),
('Confirm speakers', 'High', 'Get final confirmation from keynote speakers', 'Communication', 'Completed', 1, 1),
('Prepare welcome kits', 'Medium', 'Assemble folders with event materials', 'Admin', 'In Progress', 0, 1),
('Book photographer', 'Low', 'Hire professional photographer for event coverage', 'Media', 'Pending', 0, 1),
('Order decorations', 'Medium', 'Purchase balloons, banners, and table centerpieces', 'Decoration', 'Completed', 1, 1),
('Arrange parking', 'Medium', 'Reserve parking spots for VIP guests', 'Logistics', 'In Progress', 0, 1),
('Setup registration desk', 'High', 'Prepare check-in area with laptops and materials', 'Admin', 'Pending', 0, 1),
('Create event schedule', 'High', 'Finalize timeline and share with team', 'Planning', 'Completed', 1, 1),
('Hire security', 'Medium', 'Book security personnel for entry points', 'Security', 'In Progress', 0, 1),
('Test WiFi connection', 'High', 'Ensure stable internet for all attendees', 'Technical', 'Pending', 0, 1),
('Prepare emergency plan', 'High', 'Document evacuation procedures and first aid', 'Safety', 'Completed', 1, 1);