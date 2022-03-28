# frozen_string_literal: true

source "https://rubygems.org"
gemspec

gem "jekyll", ENV["JEKYLL_VERSION"] if ENV["JEKYLL_VERSION"]
gem "kramdown-parser-gfm" if ENV["JEKYLL_VERSION"] == "~> 4.2.2"
gem "jekyll-seo-tag", "~> 2.8.0"
gem 'wdm', '>= 0.1.1' if Gem.win_platform?