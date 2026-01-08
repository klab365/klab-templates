#include <gtest/gtest.h>
#include <core/app.h>

TEST(AppTest, RunDoesNotThrow) {
    core::App app;
    EXPECT_NO_THROW(app.run());
}

TEST(AppTest, VersionIsCorrect) {
    core::App app;
    EXPECT_EQ(app.getVersion(), "1.0.0");
}

TEST(AppTest, AppIsConstructible) {
    EXPECT_NO_THROW(core::App());
}

int main(int argc, char **argv) {
    ::testing::InitGoogleTest(&argc, argv);
    return RUN_ALL_TESTS();
}
