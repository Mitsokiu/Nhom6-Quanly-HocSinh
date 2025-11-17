-- =====================================
-- DATABASE: school_management
-- =====================================

CREATE DATABASE IF NOT EXISTS school_management
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE school_management;

-- =====================================
-- 1. USERS (Tài khoản người dùng)
-- =====================================
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    fullname VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    phone VARCHAR(15),
    role_id VARCHAR(50),  -- đổi từ INT sang VARCHAR, bỏ FK
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO users (username, password, fullname, email, phone, role_id) VALUES
('admin01', '123456', 'Nguyễn Văn A', 'admin@school.com', '0900000001', 'admin'),
('gv01', '123456', 'Trần Thị Giáo Viên', 'gv01@school.com', '0900000011', 'gvcn'),
('gv02', '123456', 'Lê Văn Thầy', 'gv02@school.com', '0900000012', 'gvbm'),
('hs01', '123456', 'Nguyễn Minh Khang', 'hs01@school.com', '0900000021', 'student'),
('hs02', '123456', 'Trần Bảo Ngọc', 'hs02@school.com', '0900000022', 'student'),
('ph01', '123456', 'Nguyễn Văn Ba', 'ph01@school.com', '0900000031', 'parent'),
('ph02', '123456', 'Trần Thị Mai', 'ph02@school.com', '0900000032', 'parent');

-- =====================================
-- 2. Parents & Students
-- =====================================
CREATE TABLE parents (
    parent_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNIQUE NOT NULL,
    job VARCHAR(100),
    FOREIGN KEY(user_id) REFERENCES users(user_id)
);

INSERT INTO parents (user_id, job) VALUES
(6, 'Kinh doanh'),
(7, 'Công chức');

CREATE TABLE students (
    student_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT UNIQUE NOT NULL,
    dob DATE,
    gender ENUM('Male','Female'),
    address TEXT,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

INSERT INTO students (user_id, dob, gender, address) VALUES
(4, '2010-05-12', 'Male', 'HCM'),
(5, '2011-09-21', 'Female', 'HCM');

CREATE TABLE student_parent (
    student_id INT,
    parent_id INT,
    relation VARCHAR(20),
    PRIMARY KEY(student_id, parent_id),
    FOREIGN KEY (student_id) REFERENCES students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (parent_id) REFERENCES parents(parent_id) ON DELETE CASCADE
);

INSERT INTO student_parent (student_id, parent_id, relation) VALUES
(1, 1, 'Cha'),
(2, 2, 'Mẹ');

-- =====================================
-- 3. Years & Semesters
-- =====================================
CREATE TABLE academic_years (
    year_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    start_date DATE,
    end_date DATE
);

INSERT INTO academic_years (name, start_date, end_date) VALUES
('2024-2025', '2024-08-01', '2025-05-30');

CREATE TABLE semesters (
    semester_id INT AUTO_INCREMENT PRIMARY KEY,
    year_id INT NOT NULL,
    name VARCHAR(20) NOT NULL,
    start_date DATE,
    end_date DATE,
    FOREIGN KEY (year_id) REFERENCES academic_years(year_id)
);

INSERT INTO semesters (year_id, name, start_date, end_date) VALUES
(1, 'Học kỳ 1', '2024-08-01', '2024-12-31'),
(1, 'Học kỳ 2', '2025-01-01', '2025-05-30');

-- =====================================
-- 4. Khối – Lớp
-- =====================================
CREATE TABLE grade_levels (
    grade_id INT AUTO_INCREMENT PRIMARY KEY,
    grade_name VARCHAR(20) NOT NULL
);

INSERT INTO grade_levels (grade_name) VALUES
('Khối 6'),
('Khối 7');

CREATE TABLE classes (
    class_id INT AUTO_INCREMENT PRIMARY KEY,
    class_name VARCHAR(50) NOT NULL,
    grade_id INT NOT NULL,
    homeroom_teacher_id INT,
    year_id INT NOT NULL,
    FOREIGN KEY (grade_id) REFERENCES grade_levels(grade_id),
    FOREIGN KEY (homeroom_teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (year_id) REFERENCES academic_years(year_id)
);

INSERT INTO classes (class_name, grade_id, homeroom_teacher_id, year_id) VALUES
('6A1', 1, 2, 1),
('6A2', 1, NULL, 1),
('7A1', 2, 3, 1);

-- =====================================
-- 5. Subjects & Teacher Assignment
-- =====================================
CREATE TABLE subjects (
    subject_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

INSERT INTO subjects (name) VALUES
('Toán'),
('Ngữ Văn'),
('Tiếng Anh'),
('Vật Lý');

CREATE TABLE teacher_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    teacher_id INT NOT NULL,
    subject_id INT NOT NULL,
    class_id INT NOT NULL,
    semester_id INT NOT NULL,
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (subject_id) REFERENCES subjects(subject_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

INSERT INTO teacher_assignments (teacher_id, subject_id, class_id, semester_id) VALUES
(2, 1, 1, 1),
(2, 2, 1, 1),
(3, 3, 1, 1);

-- =====================================
-- 6. Student - Class Assignment
-- =====================================
CREATE TABLE student_class (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    class_id INT NOT NULL,
    school_year_id INT NOT NULL,
    FOREIGN KEY(student_id) REFERENCES students(student_id),
    FOREIGN KEY(class_id) REFERENCES classes(class_id),
    FOREIGN KEY(school_year_id) REFERENCES academic_years(year_id)
);

INSERT INTO student_class (student_id, class_id, school_year_id) VALUES
(1, 1, 1),
(2, 1, 1);

-- =====================================
-- 7. Timetable
-- =====================================
CREATE TABLE timetable (
    id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT NOT NULL,
    subject_id INT NOT NULL,
    teacher_id INT NOT NULL,
    semester_id INT NOT NULL,
    day ENUM('Mon','Tue','Wed','Thu','Fri','Sat'),
    period INT,
    room VARCHAR(50),
    UNIQUE(class_id, day, period),
    FOREIGN KEY(class_id) REFERENCES classes(class_id),
    FOREIGN KEY(subject_id) REFERENCES subjects(subject_id),
    FOREIGN KEY(teacher_id) REFERENCES users(user_id),
    FOREIGN KEY(semester_id) REFERENCES semesters(semester_id)
);

INSERT INTO timetable (class_id, subject_id, teacher_id, semester_id, day, period, room) VALUES
(1, 1, 2, 1, 'Mon', 1, '101'),
(1, 2, 2, 1, 'Mon', 2, '102'),
(1, 3, 3, 1, 'Tue', 3, '103');

-- =====================================
-- 8. Scores
-- =====================================
CREATE TABLE scores (
    score_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    assign_id INT NOT NULL,
    score_type ENUM('oral','quiz15','quiz45','midterm','final'),
    score_value FLOAT CHECK (score_value >= 0 AND score_value <= 10),
    FOREIGN KEY(student_id) REFERENCES students(student_id),
    FOREIGN KEY(assign_id) REFERENCES teacher_assignments(assign_id)
);

INSERT INTO scores (student_id, assign_id, score_type, score_value) VALUES
(1, 1, 'oral', 8.0),
(1, 1, 'quiz15', 7.5),
(1, 1, 'final', 8.2),
(1, 2, 'oral', 9.0),
(1, 2, 'quiz15', 8.0),
(1, 2, 'final', 8.8),
(2, 1, 'oral', 7.0),
(2, 1, 'quiz15', 6.5),
(2, 1, 'final', 7.0);

-- =====================================
-- 9. Tuition & Receipts
-- =====================================
CREATE TABLE tuition (
    tuition_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    amount DECIMAL(10,2),
    due_date DATE,
    status ENUM('unpaid','paid') DEFAULT 'unpaid',
    FOREIGN KEY(student_id) REFERENCES students(student_id)
);

CREATE TABLE receipts (
    receipt_id INT AUTO_INCREMENT PRIMARY KEY,
    tuition_id INT NOT NULL,
    paid_date DATE,
    amount_paid DECIMAL(10,2),
    FOREIGN KEY(tuition_id) REFERENCES tuition(tuition_id)
);

INSERT INTO tuition (student_id, amount, due_date, status) VALUES
(1, 1500000, '2024-09-01', 'paid'),
(2, 1500000, '2024-09-01', 'unpaid');

INSERT INTO receipts (tuition_id, paid_date, amount_paid) VALUES
(1, '2024-09-05', 1500000);

-- =====================================
-- 10. Notifications & Comments
-- =====================================
CREATE TABLE notifications (
    id INT AUTO_INCREMENT PRIMARY KEY,
    sender_id INT NOT NULL,
    target_role ENUM('teacher','student','parent','all'),
    title VARCHAR(200),
    message TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(sender_id) REFERENCES users(user_id)
);

INSERT INTO notifications (sender_id, target_role, title, message) VALUES
(1, 'parent', 'Thông báo họp PH', 'Kính mời phụ huynh đến họp vào ngày 20/12.');

CREATE TABLE comments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    teacher_id INT NOT NULL,
    semester_id INT NOT NULL,
    comment_text TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(student_id) REFERENCES students(student_id),
    FOREIGN KEY(teacher_id) REFERENCES users(user_id),
    FOREIGN KEY(semester_id) REFERENCES semesters(semester_id)
);

INSERT INTO comments (student_id, teacher_id, semester_id, comment_text) VALUES
(1, 2, 1, 'Học sinh ngoan, tiếp thu tốt.'),
(2, 3, 1, 'Cần cố gắng hơn trong môn tiếng Anh.');

-- =====================================
-- 11. School Info & Ranking
-- =====================================
CREATE TABLE school_info (
    school_id INT AUTO_INCREMENT PRIMARY KEY,
    school_name VARCHAR(200),
    address TEXT,
    phone VARCHAR(20)
);

INSERT INTO school_info (school_name, address, phone) VALUES
('THCS Minh Khai', 'Quận 1, TP.HCM', '02822223333');

CREATE TABLE grade_rank (
    id INT AUTO_INCREMENT PRIMARY KEY,
    rank_name VARCHAR(50),
    min_score FLOAT,
    max_score FLOAT
);

INSERT INTO grade_rank (rank_name, min_score, max_score) VALUES
('Giỏi', 8.0, 10.0),
('Khá', 6.5, 7.9),
('Trung bình', 5.0, 6.4),
('Yếu', 0, 4.9);


ALTER TABLE classes
DROP FOREIGN KEY classes_ibfk_2,  -- ràng buộc của homeroom_teacher_id
DROP FOREIGN KEY classes_ibfk_3;  -- ràng buộc của year_id

ALTER TABLE classes
DROP COLUMN homeroom_teacher_id,
DROP COLUMN year_id;
ALTER TABLE teacher_assignments 
ADD COLUMN periods INT NOT NULL DEFAULT 0;


USE school_management;

CREATE TABLE homeroom_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT NOT NULL,
    teacher_id INT NOT NULL,
    year_id INT NOT NULL,
    assigned_date DATE DEFAULT (CURDATE()),

    CONSTRAINT fk_hr_class FOREIGN KEY (class_id) REFERENCES classes(class_id),
    CONSTRAINT fk_hr_teacher FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    CONSTRAINT fk_hr_year FOREIGN KEY (year_id) REFERENCES academic_years(year_id),

    CONSTRAINT unique_gvcn_per_class_per_year UNIQUE (class_id, year_id)
);

-- Thêm dữ liệu mẫu
USE school_management;
INSERT INTO homeroom_assignments (class_id, teacher_id, year_id, assigned_date) VALUES
(1, 1, 1, '2025-09-01'),
(2, 2, 1, '2025-09-01'),
(3, 3, 1, '2025-09-01');