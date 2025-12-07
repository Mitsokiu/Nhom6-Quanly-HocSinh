-- ======================
-- DATABASE
-- ======================
CREATE DATABASE IF NOT EXISTS school_management_c
CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE school_management_b;

-- ======================
-- TABLES
-- ======================
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50),
    password VARCHAR(255),
    fullname VARCHAR(100),
    email VARCHAR(100),
    phone VARCHAR(15),
    role_id VARCHAR(50),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE students (
    student_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    dob DATE,
    gender ENUM('Male','Female'),
    address TEXT,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE grade_levels (
    grade_id INT AUTO_INCREMENT PRIMARY KEY,
    grade_name VARCHAR(20)
);

CREATE TABLE classes (
    class_id INT AUTO_INCREMENT PRIMARY KEY,
    class_name VARCHAR(50),
    grade_id INT,
    FOREIGN KEY (grade_id) REFERENCES grade_levels(grade_id)
);

CREATE TABLE academic_years (
    year_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20),
    start_date DATE,
    end_date DATE
);

CREATE TABLE semesters (
    semester_id INT AUTO_INCREMENT PRIMARY KEY,
    year_id INT,
    name VARCHAR(20),
    start_date DATE,
    end_date DATE,
    FOREIGN KEY (year_id) REFERENCES academic_years(year_id)
);

CREATE TABLE subjects (
    subject_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100)
);

CREATE TABLE teacher_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    teacher_id INT,
    subject_id INT,
    class_id INT,
    semester_id INT,
    periods INT,
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (subject_id) REFERENCES subjects(subject_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

CREATE TABLE timetable (
    id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT,
    subject_id INT,
    teacher_id INT,
    semester_id INT,
    day ENUM('Mon','Tue','Wed','Thu','Fri','Sat'),
    period INT,
    room VARCHAR(50),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (subject_id) REFERENCES subjects(subject_id),
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

CREATE TABLE tuition (
    tuition_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    description VARCHAR(255),
    name VARCHAR(255),
    amount DECIMAL(10,2),
    semester_id INT,
    due_date DATE,
    status ENUM('unpaid','paid'),
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

CREATE TABLE student_evaluations (
    evaluation_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    class_id INT,
    semester_id INT,
    conduct ENUM('Tốt','Khá','Trung Bình','Yếu'),
    teacher_comment TEXT,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id),
    UNIQUE KEY unique_eval (student_id, class_id, semester_id)
);

CREATE TABLE student_class (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    class_id INT,
    school_year_id INT,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (school_year_id) REFERENCES academic_years(year_id)
);

CREATE TABLE scores (
    score_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    assign_id INT,
    score_type ENUM('oral','quiz15','quiz45','midterm','final','ave'),
    score_value FLOAT,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (assign_id) REFERENCES teacher_assignments(assign_id)
);

CREATE TABLE school_info (
    school_id INT AUTO_INCREMENT PRIMARY KEY,
    school_name VARCHAR(200),
    address TEXT,
    phone VARCHAR(20)
);

CREATE TABLE notifications (
    id INT AUTO_INCREMENT PRIMARY KEY,
    sender_id INT,
    target_role ENUM('teacher','student','parent','all'),
    title VARCHAR(200),
    message TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (sender_id) REFERENCES users(user_id)
);

CREATE TABLE homeroom_assignments (
    assign_id INT AUTO_INCREMENT PRIMARY KEY,
    class_id INT,
    teacher_id INT,
    year_id INT,
    assigned_date DATE,
    FOREIGN KEY (class_id) REFERENCES classes(class_id),
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (year_id) REFERENCES academic_years(year_id)
);

CREATE TABLE grade_rank (
    id INT AUTO_INCREMENT PRIMARY KEY,
    rank_name VARCHAR(50),
    min_score FLOAT,
    max_score FLOAT
);

CREATE TABLE comments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    teacher_id INT,
    semester_id INT,
    comment_text TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (teacher_id) REFERENCES users(user_id),
    FOREIGN KEY (semester_id) REFERENCES semesters(semester_id)
);

-- ======================================
-- INSERT DATA
-- ======================================
-- USERS: 5 admin, 5 student, 5 gvcn, 5 gvbm
INSERT INTO users (username,password,fullname,email,phone,role_id) VALUES
('admin1','123','Admin One','admin1@mail.com','0900000001','admin'),
('admin2','123','Admin Two','admin2@mail.com','0900000002','admin'),
('admin3','123','Admin Three','admin3@mail.com','0900000003','admin'),
('admin4','123','Admin Four','admin4@mail.com','0900000004','admin'),
('admin5','123','Admin Five','admin5@mail.com','0900000005','admin'),

('student1','123','Student One','st1@mail.com','0911111111','student'),
('student2','123','Student Two','st2@mail.com','0911111112','student'),
('student3','123','Student Three','st3@mail.com','0911111113','student'),
('student4','123','Student Four','st4@mail.com','0911111114','student'),
('student5','123','Student Five','st5@mail.com','0911111115','student'),

('gvcn1','123','GVCN One','gvcn1@mail.com','0922222221','gvcn'),
('gvcn2','123','GVCN Two','gvcn2@mail.com','0922222222','gvcn'),
('gvcn3','123','GVCN Three','gvcn3@mail.com','0922222223','gvcn'),
('gvcn4','123','GVCN Four','gvcn4@mail.com','0922222224','gvcn'),
('gvcn5','123','GVCN Five','gvcn5@mail.com','0922222225','gvcn'),

('gvbm1','123','GVBM One','gvbm1@mail.com','0933333331','gvbm'),
('gvbm2','123','GVBM Two','gvbm2@mail.com','0933333332','gvbm'),
('gvbm3','123','GVBM Three','gvbm3@mail.com','0933333333','gvbm'),
('gvbm4','123','GVBM Four','gvbm4@mail.com','0933333334','gvbm'),
('gvbm5','123','GVBM Five','gvbm5@mail.com','0933333335','gvbm');

-- STUDENTS = 5
INSERT INTO students (user_id,dob,gender,address)
SELECT user_id,'2010-01-01','Male','HCM City'
FROM users WHERE role_id='student';

-- GRADE LEVELS
INSERT INTO grade_levels (grade_name) VALUES
('Grade 6'),('Grade 7'),('Grade 8');

-- CLASSES
INSERT INTO classes (class_name,grade_id) VALUES
('6A1',1),('6A2',1),
('7A1',2),('7A2',2),
('8A1',3);

-- ACADEMIC YEARS
INSERT INTO academic_years (name,start_date,end_date) VALUES
('2024-2025','2024-09-01','2025-05-31');

-- SEMESTERS
INSERT INTO semesters (year_id,name,start_date,end_date) VALUES
(1,'HK1','2025-09-01','2025-12-31'),
(1,'HK2','2026-01-01','2026-05-31');

-- SUBJECTS
INSERT INTO subjects(name) VALUES
('Math'),('Physics'),('Chemistry'),('English'),('History');

-- TEACHER ASSIGNMENTS
INSERT INTO teacher_assignments(teacher_id,subject_id,class_id,semester_id,periods) VALUES
(11,1,1,1,4),
(12,2,1,1,3),
(13,3,2,1,2),
(14,4,2,1,3),
(15,5,3,1,2);

-- TIMETABLE
INSERT INTO timetable(class_id,subject_id,teacher_id,semester_id,day,period,room) VALUES
(1,1,11,1,'Mon',1,'A1'),
(1,2,12,1,'Tue',2,'A1'),
(2,3,13,1,'Wed',3,'A2');

-- TUITION
INSERT INTO tuition(student_id,description,name,amount,semester_id,due_date,status) VALUES
(1,'Học phí HK1','Tuition HK1',2000000,1,'2024-10-01','unpaid'),
(2,'Học phí HK1','Tuition HK1',2000000,1,'2024-10-01','paid');

-- STUDENT EVALUATIONS
INSERT INTO student_evaluations(student_id,class_id,semester_id,conduct,teacher_comment) VALUES
(1,1,1,'Tốt','Chăm ngoan'),
(2,1,1,'Khá','Tiến bộ');

-- STUDENT CLASS
INSERT INTO student_class(student_id,class_id,school_year_id) VALUES
(1,1,1),(2,1,1),(3,2,1),(4,2,1),(5,3,1);

-- SCORES
INSERT INTO scores(student_id,assign_id,score_type,score_value) VALUES
(1,1,'oral',9),
(1,1,'quiz15',8),
(1,1,'final',9.5);

-- SCHOOL INFO
INSERT INTO school_info(school_name,address,phone) VALUES
('Trường THCS ABC','HCM City','0900009999');

-- NOTIFICATIONS
INSERT INTO notifications(sender_id,target_role,title,message) VALUES
(1,'all','Thông báo khai giảng','Ngày khai giảng 5/9');

-- HOMEROOM ASSIGNMENTS
INSERT INTO homeroom_assignments(class_id,teacher_id,year_id,assigned_date) VALUES
(1,11,1,'2024-08-20');

-- GRADE RANK
INSERT INTO grade_rank(rank_name,min_score,max_score) VALUES
('Giỏi',8.0,10.0),
('Khá',6.5,7.9),
('Trung Bình',5.0,6.4),
('Yếu',0,4.9);

-- COMMENTS
INSERT INTO comments(student_id,teacher_id,semester_id,comment_text) VALUES
(1,11,1,'Tiếp tục phát huy.');


ALTER TABLE student_class
DROP FOREIGN KEY student_class_ibfk_1;

ALTER TABLE student_class
ADD CONSTRAINT student_class_ibfk_1
FOREIGN KEY (student_id)
REFERENCES students(student_id)
ON DELETE CASCADE;


ALTER TABLE teacher_assignments
DROP FOREIGN KEY teacher_assignments_ibfk_1;

ALTER TABLE teacher_assignments
ADD CONSTRAINT teacher_assignments_ibfk_1
FOREIGN KEY (teacher_id)
REFERENCES users(user_id)
ON DELETE CASCADE;
