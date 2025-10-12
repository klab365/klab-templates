FROM rust:1.89.0-slim-bookworm AS ci

# Install rust version and components
RUN <<EOF
    set -eu
    apt update
    apt install -y curl

    curl --proto '=https' --tlsv1.2 -sSf https://just.systems/install.sh | bash -s -- --to /usr/local/bin

    # Install rust components for CI
    rustup component add rustfmt clippy

    # cleanup
    apt-get clean
    rm -rf /var/lib/apt/lists/*
EOF

FROM ci AS development

# Install additional dependencies for development
ARG UID=1000
RUN <<EOF
    set -eu
    apt update
    apt install -y zsh git curl sudo pkg-config libssl-dev

    # create a user dev with the UID and the sudo group
    useradd -m -u $UID -G sudo dev
    echo "dev ALL=(ALL) NOPASSWD:ALL" >> /etc/sudoers

    # Setup shell for dev user
    chsh -s /bin/zsh dev
    su - dev -c 'sh -c "$(curl -fsSL https://raw.github.com/ohmyzsh/ohmyzsh/master/tools/install.sh)" "" --unattended'
    su - dev -c 'git clone https://github.com/zsh-users/zsh-autosuggestions ${ZSH_CUSTOM:-~/.oh-my-zsh/custom}/plugins/zsh-autosuggestions'
    su - dev -c 'sed -i "s/plugins=(git)/plugins=(git zsh-autosuggestions)/" ~/.zshrc'
    curl -sS https://starship.rs/install.sh | sh -s -- --yes
    su - dev -c 'echo "eval \"\$(starship init zsh)\"" >> ~/.zshrc'

    # Create cargo directory for dev user
    mkdir -p /home/dev/.cargo
    chown -R dev:dev /home/dev/.cargo
    su - dev -c 'echo "export CARGO_HOME=/home/dev/.cargo" >> ~/.zshrc'

    # Install Rust tools
    cargo install cargo-watch

    # cleanup
    apt-get clean
    rm -rf /var/lib/apt/lists/*
EOF

