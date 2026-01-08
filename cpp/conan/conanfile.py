from conan import ConanFile
from conan.tools.cmake import CMakeToolchain, CMake, cmake_layout


class MyAppConan(ConanFile):
    name = "myapp"
    version = "0.0.0"
    
    # Binary configuration
    settings = "os", "compiler", "build_type", "arch"
    options = {"shared": [True, False], "fPIC": [True, False]}
    default_options = {"shared": False, "fPIC": True}
    
    def config_options(self):
        if self.settings.os == "Windows":
            del self.options.fPIC
    
    def configure(self):
        if self.options.shared:
            self.options.rm_safe("fPIC")
    
    def requirements(self):
        # Add your dependencies here, e.g.:
        # self.requires("fmt/10.1.1")
        self.test_requires("gtest/1.17.0")
    
    def layout(self):
        cmake_layout(self, build_folder="build")
    
    def generate(self):
        tc = CMakeToolchain(self)
        tc.generate()
    
    def build(self):
        cmake = CMake(self)
        cmake.configure()
        cmake.build()
    
    def package(self):
        cmake = CMake(self)
        cmake.install()
