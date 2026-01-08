#include "core/app.h"
#include <iostream>

namespace myapp {

App::App() : version_("1.0.0") {}

void App::run() {
    std::cout << "Hello from MyApp!" << std::endl;
    std::cout << "Version: " << getVersion() << std::endl;
}

std::string App::getVersion() const {
    return version_;
}

} // namespace myapp
