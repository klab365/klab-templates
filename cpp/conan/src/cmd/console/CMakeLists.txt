cmake_minimum_required(VERSION 3.15)
project(console LANGUAGES CXX)

add_executable(cmd src/main.cpp)

# link core and adapters libraries
target_link_libraries(cmd PRIVATE core adapters)
